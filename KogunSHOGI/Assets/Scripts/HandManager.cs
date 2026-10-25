using UnityEngine;
using System.Collections.Generic;

public class HandManager : MonoBehaviour
{
    public static HandManager instance;

    public static List<koma_hontai> blackHand = new List<koma_hontai>();
    public static List<koma_hontai> whiteHand = new List<koma_hontai>();
    
    // Update is called once per frame
    void Awake()
    {
        instance = this;
    }
    
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
        if (koma.isBlack)
            blackHand.Remove(koma);
        else
            whiteHand.Remove(koma);

        koma.x = x;
        koma.y = y;

        BoardManager.board[x - 1, y - 1] = koma;
        // 表示する
        koma.gameObject.SetActive(true);

        // 位置を更新
        koma.transform.position = new Vector3(x - 5, y - 5, 0);
    }
}
