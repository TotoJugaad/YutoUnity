using UnityEngine;
using UnityEngine.InputSystem;

public enum PieceType{
    Pawn,
    Lance,
    Knight,
    Silver,
    Gold,
    Bishop,
    Rook,
    King
}


public class koma_hontai : MonoBehaviour
{
    //move patterns for each piece type
    private static readonly Vector2Int[] pawnMoves =
    {
        new Vector2Int(0, 1)
    };
    private static readonly Vector2Int[] knightMoves =
    {
        new Vector2Int(-1, 2),
        new Vector2Int(1, 2)
    };
    private static readonly Vector2Int[] silverMoves =
    {
        new Vector2Int(0, 1),
        new Vector2Int(-1, 1),
        new Vector2Int(1, 1),
        new Vector2Int(-1, -1),
        new Vector2Int(1, -1)
    };
    private static readonly Vector2Int[] goldMoves =
    {
        new Vector2Int(0, 1),
        new Vector2Int(1, 1),
        new Vector2Int(-1, 1),
        new Vector2Int(1, 0),
        new Vector2Int(-1, 0),
        new Vector2Int(0, -1)
    };
    private static readonly Vector2Int[] kingMoves =
    {
        new Vector2Int(0, 1),
        new Vector2Int(1, 1),
        new Vector2Int(-1, 1),
        new Vector2Int(1, 0),
        new Vector2Int(-1, 0),
        new Vector2Int(0, -1),
        new Vector2Int(1, -1),
        new Vector2Int(-1, -1)
    };
    // Directions for pieces that can move multiple squares in a straight line
    private static readonly Vector2Int[] rookDirections =
    {
        new Vector2Int(1, 0),
        new Vector2Int(-1, 0),
        new Vector2Int(0, 1),
        new Vector2Int(0, -1)
    };
    private static readonly Vector2Int[] bishopDirections =
    {
        new Vector2Int(1, 1),
        new Vector2Int(1, -1),
        new Vector2Int(-1, 1),
        new Vector2Int(-1, -1)
    };
    private static readonly Vector2Int[] blackLanceDirections =
    {
        new Vector2Int(0, 1)
    };
    private static readonly Vector2Int[] whiteLanceDirections =
    {
        new Vector2Int(0, -1)
    };

    public int x;
    public int y;

    public bool isBlack;
    public bool isPromoted;

    public PieceType pieceType;
    
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void ImageSet(int index)
    {
        sr.sprite = KomaData.Images[index];
    }
    
    public void Move(int newX, int newY)
    {
        BoardManager.board[x-1,y-1] = null;
        
        x = newX;
        y = newY;

        BoardManager.board[x-1,y-1] = this;
        transform.position = new Vector3(x-5, y-5, 0);
    }   

    bool MatchMove(Vector2Int[] moves, int dx, int dy)
    {
        foreach (Vector2Int move in moves)
        {
            if (move.x == dx && move.y == dy)
            {
            return true;
            }
        }

        return false;
    }

    bool CanSlide(Vector2Int[] directions, int newX, int newY)
    {
        foreach (Vector2Int dir in directions)
        {
            int nx = x + dir.x;
            int ny = y + dir.y;

            while (nx >= 1 && nx <= 9 &&
                ny >= 1 && ny <= 9)
            {
            // 目的地まで来た
                if (nx == newX && ny == newY)
                {
                    return true;
                }

            // 途中に駒があったら止まる
                if (BoardManager.board[nx - 1, ny - 1] != null)
                {
                    break;
                }

                nx += dir.x;
                ny += dir.y;
            }
        }

    return false;
    }
    
    public bool CanMove(int newX, int newY)
    {
        int dx = newX - x;
        int dy = newY - y;
        
        if (newX < 1 || newX > 9 || newY < 1 || newY > 9)
        {
            return false;
        }

        koma_hontai target = BoardManager.board[newX - 1, newY - 1];

        if (target != null && target.isBlack == isBlack)
        {
            return false;
        }

        

        switch (pieceType)
        {
            case PieceType.Pawn:
                return MatchMove(pawnMoves, dx, dy);

            case PieceType.Knight:
                return MatchMove(knightMoves, dx, dy);

            case PieceType.Silver:
                return MatchMove(silverMoves, dx, dy);

            case PieceType.Gold:
                return MatchMove(goldMoves, dx, dy);

            case PieceType.King:
                return MatchMove(kingMoves, dx, dy);

            case PieceType.Rook:
                return CanSlide(rookDirections, newX, newY);

            case PieceType.Bishop:
                return CanSlide(bishopDirections, newX, newY);

            case PieceType.Lance:
                return CanSlide(isBlack ? blackLanceDirections : whiteLanceDirections,
                newX, newY);
            default:
                return false;
        }
        
    }

    void OnMouseDown()
    {
        BoardManager.selectedKoma = this;
        BoardManager.pieceJustSelected = true;
        Debug.Log(pieceType + "を選択");
        //Debug.Log("Clicked on " + pieceType.ToString() + " at (" + x + ", " + y + ")");
    }

    void Capture(koma_hontai target)
    {
        // 盤から消す
        BoardManager.board[target.x - 1, target.y - 1] = null;

        // 成り解除
        target.isPromoted = false;

        // 所有者変更
        target.isBlack = isBlack;

        // 持ち駒へ
        HandManager.Add(target, isBlack);
        // 画面から消す
        target.gameObject.SetActive(false);
    }
}
