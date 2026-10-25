using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static PieceType selectedHandPiece = PieceType.Unselected;
    public static bool selectedHandBlack;
    public static koma_hontai[,] board = new koma_hontai[9, 9];
    public static koma_hontai selectedKoma;
    public static bool isWaitingForMoveClick;

    void Update()
    {
        if (selectedKoma == null)
        {
            return;
        }  

        if (Input.GetMouseButtonDown(0))
        {  
            isWaitingForMoveClick = false; 
            // マウス座標を計算
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = -Camera.main.transform.position.z;

            Vector3 mouse = Camera.main.ScreenToWorldPoint(mousePos);

            int x = Mathf.RoundToInt(mouse.x + 5);
            int y = Mathf.RoundToInt(mouse.y + 5);

            Debug.Log($"2回目クリック: ({x},{y})");
            Debug.Log("WaitingForLove");

            // 移動判定と実行
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

            // 移動を試みたら成否に関わらず選択を解除
            selectedKoma = null;
            isWaitingForMoveClick = false;
        }
    }
}
