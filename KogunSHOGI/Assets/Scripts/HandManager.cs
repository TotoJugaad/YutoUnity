using UnityEngine;
using System.Collections.Generic;

public class HandManager : MonoBehaviour
{

    public static List<koma_hontai> blackHand = new List<koma_hontai>();
    public static List<koma_hontai> whiteHand = new List<koma_hontai>();
    
    public static void Add(koma_hontai koma, bool black)
    {
        koma.isBlack = black;
        koma.isPromoted = false;

        if (black)
            blackHand.Add(koma);
        else
            whiteHand.Add(koma);
    }

    public static void Release(koma_hontai koma, int x, int y)
    {
        List<koma_hontai> hand = koma.isBlack
            ? blackHand
            : whiteHand;
        
        hand.Remove(koma);

        bool hasAnother = hand.Exists(
            p => p != null && p.pieceType == koma.pieceType
        );
        
        HandKoma icon = koma.isBlack
            ? koma.blackHandIcon
            : koma.whiteHandIcon;
        
        if (icon != null)
        {
            icon.gameObject.SetActive(hasAnother);
        }
        
        koma.x = x;
        koma.y = y;

        BoardManager.board[x - 1, y - 1] = koma;
        // 表示する
        koma.gameObject.SetActive(true);

        // 位置を更新
        koma.transform.position = new Vector3(x - 5, y - 5, 0);
    }
}
