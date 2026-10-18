using UnityEngine;
using System.Collections.Generic;

public class place_koma : MonoBehaviour
{   
    public GameObject komaPrefab;

    void Start()
    {
        for (int i = 1; i <= 9; i++)
        {
        Spawn(i,3, PieceType.Pawn, true,(int)KomaData.PieceImage.BlackPawn);
        Spawn(i,7, PieceType.Pawn, false,(int)KomaData.PieceImage.WhitePawn);
        }
        //Black rank:1
        Spawn(1,1, PieceType.Lance, true,(int)KomaData.PieceImage.BlackLance);
        Spawn(2,1, PieceType.Knight, true,(int)KomaData.PieceImage.BlackKnight);
        Spawn(3,1, PieceType.Silver, true,(int)KomaData.PieceImage.BlackSilver);
        Spawn(4,1, PieceType.Gold, true,(int)KomaData.PieceImage.BlackGold);
        Spawn(5,1, PieceType.King, true,(int)KomaData.PieceImage.BlackKing);
        Spawn(6,1, PieceType.Gold, true,(int)KomaData.PieceImage.BlackGold);
        Spawn(7,1, PieceType.Silver, true,(int)KomaData.PieceImage.BlackSilver);
        Spawn(8,1, PieceType.Knight, true,(int)KomaData.PieceImage.BlackKnight);
        Spawn(9,1, PieceType.Lance, true,(int)KomaData.PieceImage.BlackLance);
        //rank:2
        Spawn(2,2, PieceType.Bishop, true,(int)KomaData.PieceImage.BlackBishop);
        Spawn(8,2, PieceType.Rook, true,(int)KomaData.PieceImage.BlackRook);
        //White rank:9
        Spawn(1,9, PieceType.Lance, false,(int)KomaData.PieceImage.WhiteLance);
        Spawn(2,9, PieceType.Knight, false,(int)KomaData.PieceImage.WhiteKnight);
        Spawn(3,9, PieceType.Silver, false,(int)KomaData.PieceImage.WhiteSilver);
        Spawn(4,9, PieceType.Gold, false,(int)KomaData.PieceImage.WhiteGold);
        Spawn(5,9, PieceType.King, false,(int)KomaData.PieceImage.WhiteKing);
        Spawn(6,9, PieceType.Gold, false,(int)KomaData.PieceImage.WhiteGold);
        Spawn(7,9, PieceType.Silver, false,(int)KomaData.PieceImage.WhiteSilver);
        Spawn(8,9, PieceType.Knight, false,(int)KomaData.PieceImage.WhiteKnight);
        Spawn(9,9, PieceType.Lance, false,(int)KomaData.PieceImage.WhiteLance);
        //rank:8
        Spawn(8,8, PieceType.Bishop, false,(int)KomaData.PieceImage.WhiteBishop);
        Spawn(2,8, PieceType.Rook, false,(int)KomaData.PieceImage.WhiteRook);
    }

    void Spawn(int x, int y, PieceType pieceType, bool isBlack, int spriteIndex)
    {
        GameObject obj = Instantiate(
            komaPrefab,
            new Vector3(x-5, y-5, 0),
            Quaternion.identity
        );

        koma_hontai koma = 
            obj.GetComponent<koma_hontai>();

        koma.ImageSet(spriteIndex);
        
        koma.x = x;
        koma.y = y;

        koma.pieceType = pieceType;
        koma.isBlack = isBlack;

        BoardManager.board[x-1,y-1] = koma;
    }
}
//
