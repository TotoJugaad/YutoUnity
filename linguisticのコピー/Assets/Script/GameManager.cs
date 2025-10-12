using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public ChangeFlags changeFlags;
    public KotaeTexy kotaeText;
    public Click click;
    public ImageList SpriteList;
    [Space(10)]
    public int listLength;
    [Header("表示するフラッグ")]
    public int flagNumber;
    public string listName = "Asia";
    [System.NonSerialized]public string[] listNamae = new string[]
    {
        "All",
        "USSR"
    };
    void Update()
    {
        if (bool.Parse(PlayerPrefs.GetString("IFClick")) && !click.furagu)
        {
            kotaeText.namaeNull();
            switch (PlayerPrefs.GetInt("Chiiki")){
                case 0:
                    flagNumber = Random.Range(0, kotaeText.GengoMei.Length);
                    break;
                case 1: break;
            };
            
            changeFlags.changeFlagNumber(flagNumber/*, listNamae[PlayerPrefs.GetInt("Chiiki")]*/);
            kotaeText.kokkiKazu = flagNumber;
            kotaeText.listName = listNamae[PlayerPrefs.GetInt("Chiiki")];
            StartCoroutine(kotaeText.WaitForSpacePressCoroutine());
            click.furagu = true;
        }
    }
}
