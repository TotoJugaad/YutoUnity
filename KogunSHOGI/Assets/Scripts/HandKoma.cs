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
    private SpriteRenderer sr;

    /*void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }*/
    /*public void UpdateSprite()
    {
        if (sr == null)
        {
            sr = GetComponent<SpriteRenderer>();
        }

        if (sr == null || KomaData.Images == null) return;

        int index = (int)pieceType;

        if (!isBlack)
        {
            index += 15;
        }

        if (index >= 0 && index < KomaData.Images.Length)
        {
            sr.sprite = KomaData.Images[index];
        }
        
    }*/
    void OnMouseDown()
    {
        BoardManager.selectedHandPiece = pieceType;
        BoardManager.selectedHandBlack = isBlack;

        Debug.Log($"{pieceType}を選択（先手：{isBlack}）");
    }
    /*public void SetHandIconActive(PieceType type, bool black, bool active)
    {
        HandKoma icon = GetIcon(type, black);

        if (icon != null)
        {
            icon.gameObject.SetActive(active);
        }
    }*/
}
