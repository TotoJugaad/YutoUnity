using UnityEngine;
using UnityEngine.InputSystem;

public class BoardManager : MonoBehaviour
{
    public static PieceType selectedHandPiece = PieceType.Unselected;
    public static bool selectedHandBlack;
    public static koma_hontai[,] board = new koma_hontai[9, 9];
    public static koma_hontai selectedKoma;
    public static bool isWaitingForMoveClick;
    public HandManager handManager;
    Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        if (mainCamera == null)
        {
            Debug.LogError("MainCameraが見つかりません");
            return;
        }
        if (Mouse.current == null) return;

        if (!Mouse.current.leftButton.wasPressedThisFrame)
            return;

        Vector2 screenPos = Mouse.current.position.ReadValue();

        Vector3 mousePos = new Vector3(
            screenPos.x,
            screenPos.y,
            -mainCamera.transform.position.z
        );

        Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);

        Collider2D hit = Physics2D.OverlapPoint(worldPos);

        // 持ち駒アイコンをクリックした場合
        if (hit != null &&
        handManager.TrySelectHandIcon(hit.gameObject))
        {
            return;
        }
    
        int x = Mathf.RoundToInt(worldPos.x + 5);
        int y = Mathf.RoundToInt(worldPos.y + 5);

        // 盤外なら終了
        if (x < 1 || x > 9 || y < 1 || y > 9)
            return;
        
        // 持ち駒を打つ場合
        if (selectedHandPiece != PieceType.Unselected)
        {
            DropHandPiece(x, y);
            return;
        }
        // 盤上の駒を選択する場合
        if (selectedKoma == null)
        {
            if (hit != null)
            {
                selectedKoma = hit.GetComponent<koma_hontai>();

                if (selectedKoma != null)
                    Debug.Log(selectedKoma.pieceType + "を選択");
            }

            return;
        }
        // 盤上の駒を移動する場合
        if (selectedKoma.CanMove(x, y))
        {
            koma_hontai target = board[x - 1, y - 1];

            if (target != null)
            {
                selectedKoma.Capture(target);
                Debug.Log("駒を取りました: " + target.pieceType);
            }

            selectedKoma.Move(x, y);
            Debug.Log("移動成功: " + x + "," + y);
        }
        else
        {
            Debug.Log("CanMove = false");
        }
        selectedKoma = null;
    }
    void DropHandPiece(int x, int y)
    {
        // すでに駒がある場所には打てない
        if (board[x - 1, y - 1] != null)
        {
            Debug.Log("その場所には駒を打てません");
            return;
        }

        koma_hontai koma = HandManager.GetHandPiece(
            selectedHandPiece,
            selectedHandBlack
        );

        if (koma == null)
        {
            Debug.LogWarning("持ち駒が見つかりません");
            selectedHandPiece = PieceType.Unselected;
            return;
        }

        if (HandManager.Release(koma, x, y))
        {
            selectedHandPiece = PieceType.Unselected;
            Debug.Log($"持ち駒を配置: {koma.pieceType} ({x},{y})");
        }
    }
}
