using UnityEngine;
using TMPro;

public class HandKoma : MonoBehaviour
{
    [Header("持ち駒の種類")]
    [SerializeField] private PieceType pieceType = PieceType.Pawn;

    [Header("先手ならチェック")]
    [SerializeField] private bool isBlack;

    public PieceType PieceType => pieceType;
    public bool IsBlack => isBlack;


    [Header("枚数表示")]
    public TMP_Text countText;
    void OnMouseDown()
    {
        BoardManager.selectedHandPiece = pieceType;
        BoardManager.selectedHandBlack = isBlack;

        Debug.Log($"{pieceType}を選択（先手：{isBlack}）");
    }
}
