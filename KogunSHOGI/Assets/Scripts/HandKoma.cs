using UnityEngine;

public class HandKoma : MonoBehaviour
{
    public PieceType pieceType;
    public bool isBlack;

    void OnMouseDown()
    {
        BoardManager.selectedHandPiece = pieceType;
        BoardManager.selectedHandBlack = isBlack;
    

        Debug.Log(pieceType + "を選択");
    }
}
