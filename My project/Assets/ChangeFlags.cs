using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeFlags : MonoBehaviour
{
    public Image targetImage;
    public ImageList SpriteList;
    public int listLength;
    [System.NonSerialized] public Vector2[] KokkiOkisa = new Vector2[]
        {
            new Vector2(900,600),//3:2
            new Vector2(1200,600),//2:1
            new Vector2(1000,600),//5:3
            new Vector2(960,600),//8:5
            new Vector2(1180,600),//19:10
            new Vector2(1066,600),//16:9
            new Vector2(800,600),//4:3
        };

    public void changeFlagNumber(int number, string Namae)
    {
        switch (Namae)
        {
            case "ITL":
                targetImage.sprite = SpriteList.ITL[number];
                listLength = 6;
                break;
            case "Africa":
                targetImage.sprite = SpriteList.Africa[number];
                listLength = 0;
                break;
            case "America":
                targetImage.sprite = SpriteList.America[number];
                listLength = 0;
                break;
            case "Europe":
                targetImage.sprite = SpriteList.Europe[number];
                listLength = 1;
                break;
            case "Asia":
                targetImage.sprite = SpriteList.Asia[number];
                listLength = 2;
                break;
            case "USSR":
                targetImage.sprite = SpriteList.USSR[number];
                listLength = 14;
                break;
        }
        RectTransform rectTransform = targetImage.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.sizeDelta = KokkiOkisa[int.Parse(targetImage.sprite.name.Substring(0, 1))];
        }
        else
        {
            Debug.LogError("RectTransformが見つかりませんでした。");
        }
    }

    /*public void changeFlags(string name)
    {
        foreach (Sprite SpriteOne in SpriteList.ITL)
        {
            if (SpriteOne.name == name)
            {
                targetImage.sprite = SpriteOne;
                SetImageSize(targetImage, KokkiOkisa[name[0]]);
                break;
            }
        }
    }*/
}