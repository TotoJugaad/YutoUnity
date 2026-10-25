using UnityEngine;
using TMPro;

public class HandKoma : MonoBehaviour
{
    public PieceType pieceType;
    public bool isBlack;

    [Header("枚数表示")]
    public TMP_Text countText;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }
    public void UpdateSprite()
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
        void OnMouseDown()
        {
            BoardManager.selectedHandPiece = pieceType;
            BoardManager.selectedHandBlack = isBlack;

            Debug.Log(pieceType + "を選択");
        }
    }
}
