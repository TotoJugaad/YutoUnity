using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static PieceType? selectedHandPiece = null;
    public static bool selectedHandBlack;
    public static koma_hontai[,] board = new koma_hontai[9, 9];
    public static koma_hontai selectedKoma;
    public static bool pieceJustSelected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pieceJustSelected)
        {
            pieceJustSelected = false;
            return;
        }
        
        if(selectedKoma == null)
            return;

        if(Input.GetMouseButtonDown(0)){
            Vector3 mouse =
                Camera.main.ScreenToWorldPoint(
                    Input.mousePosition);

            int x = Mathf.RoundToInt(mouse.x + 5);
            int y = Mathf.RoundToInt(mouse.y + 5);

            Debug.Log(x + "," + y);

            if (selectedKoma.CanMove(x, y))
            {
                selectedKoma.Move(x, y);
            }

            selectedKoma = null;
        }
    }
}
