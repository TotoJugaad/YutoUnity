using UnityEngine;

public class KomaData : MonoBehaviour
{
    public static Sprite[] Images;

    [SerializeField]
    private Sprite[] images = new Sprite[30];

    public enum PieceImage{
    //0-14 black pieces
        BlackPawn,
        BlackLance,
        BlackKnight,
        BlackSilver,
        BlackGold,
        BlackBishop,
        BlackRook,
        BlackKing,
        BlackKing2,
        BlackPromPawn,
        BlackPromLance,
        BlackPromKnight,
        BlackPromSilver,
        BlackHorse,
        BlackDragon,
    //15-29 white pieces
        WhitePawn,
        WhiteLance,
        WhiteKnight,
        WhiteSilver,
        WhiteGold,
        WhiteBishop,
        WhiteRook,
        WhiteKing,
        WhiteKing2,
        WhitePromPawn,
        WhitePromLance,
        WhitePromKnight,
        WhitePromSilver,
        WhiteHorse,
        WhiteDragon
    }
    void Awake()
    {
        Images = images;
    }
}