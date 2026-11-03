using UnityEngine;
using System.Collections.Generic;

public class HandManager : MonoBehaviour
{
    public static HandManager instance;
    // 持ち駒の枚数    // [0, 駒の種類] = 白   // [1, 駒の種類] = 黒
    public static int[,] Mochigoma = new int[2, 7];

    public static List<koma_hontai> blackHand = new List<koma_hontai>();
    public static List<koma_hontai> whiteHand = new List<koma_hontai>();

    [SerializeField] private GameObject[] AllHandIcons = new GameObject[14];
    
    
    void Awake()
    {
        instance = this;
        foreach (GameObject icon in AllHandIcons)
        {
            if (icon != null)
            {
                icon.SetActive(false);
            }
        }
    }
    private static int GetSideIndex(bool isBlack)
    {
        return isBlack ? 1 : 0;
    }

    public void SetHandIconActive(PieceType pieceType, bool isBlack, bool active)
    {
        int index = (isBlack ? 7 : 0) + (int)pieceType;
        if (index < 0 || index >= AllHandIcons.Length)
        {
            Debug.LogWarning("持ち駒アイコンの番号が範囲外です: " + index);
            return;
        }

        if (AllHandIcons[index] == null)
        {
            Debug.LogWarning("持ち駒アイコンが設定されていません: " + index);
            return;
        }
        AllHandIcons[index].SetActive(active);
    }
    public static void Add(koma_hontai koma, bool isBlack)
    {
        Debug.Log("Year Add Daze");
        if (koma == null)
            return;
        koma.isBlack = isBlack;
        koma.isPromoted = false;
        int side = GetSideIndex(isBlack);
        int type = (int)koma.pieceType;

        if (type < 0 || type >= 7)
        {
            Debug.LogWarning("持ち駒にできない駒です: " + koma.pieceType);
            return;
        }

        Mochigoma[side, type]++;

        // 実体をリストに保管
        if (isBlack)
            blackHand.Add(koma);
        else
            whiteHand.Add(koma);

        // 枚数に応じてアイコンを表示
        instance.SetHandIconActive(
            koma.pieceType,
            isBlack,
            Mochigoma[side, type] > 0
        );
    }

    public static void Release(koma_hontai koma, int x, int y)
    {
        if (koma == null)
            return;

        int side = GetSideIndex(koma.isBlack);
        int type = (int)koma.pieceType;

        if (type < 0 || type >= 7)
        {
            Debug.LogWarning("持ち駒にできない駒です: " + koma.pieceType);
            return;
        }

        // 枚数が0なら打てない
        if (Mochigoma[side, type] <= 0)
        {
            Debug.LogWarning("持ち駒がありません: " + koma.pieceType);
            return;
        }

        List<koma_hontai> hand = koma.isBlack
            ? blackHand
            : whiteHand;
        
        if (!hand.Remove(koma))
        {
            Debug.LogWarning("持ち駒リストに駒が見つかりません");
            return;
        }
        Mochigoma[side, type]--;

        instance.SetHandIconActive(
            koma.pieceType,
            koma.isBlack,
            Mochigoma[side, type] > 0
        );
        // 盤上に戻す
        koma.x = x;
        koma.y = y;
        BoardManager.board[x - 1, y - 1] = koma;
        // 表示する
        koma.gameObject.SetActive(true);

        // 位置を更新
        koma.transform.position = new Vector3(x - 5, y - 5, 0);
    }
    public GameObject GetHandIcon(PieceType type, bool black)
    {
        int index = (black ? 7 : 0) + (int)type;
        return AllHandIcons[index];
    }
    
}
