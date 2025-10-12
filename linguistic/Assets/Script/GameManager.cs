using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public ChangeFlags changeFlags;
    public KotaeTexy kotaeText;
    public Click click;
    [Space(10)]
    public bool answerd = true;
    [Header("表示するフラッグ")]
    public int flagNumber;
    public string listName = "Asia";
    [System.NonSerialized] public int Chiiki;
    [System.NonSerialized]public string[] listNamae = new string[]
    {
        "All",
        "USSR"
    };

    private void Start()
    {
        spacePresd();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePresd();
        }
    }
    public void changeAnswerd()
    {
        answerd = true;
    }
    public void spacePresd()
    {
        if (answerd)
        {
            kotaeText.namaeNull();//ここより下は、初期化49~57行
            switch (PlayerPrefs.GetInt("Chiiki"))
            {
                case 0: flagNumber = Random.Range(0, changeFlags.mondaiText.Length); break;
                case 1: break;
            };
            changeFlags.changeFlagNumber(flagNumber/*, listNamae[PlayerPrefs.GetInt("Chiiki")]*/);
            kotaeText.kokkiKazu = flagNumber / 3;
            //kotaeText.listName = listNamae[PlayerPrefs.GetInt("Chiiki")];
            answerd = false;
        }
        else
        {
            kotaeText.kotaeHyoji();
            answerd = true;
        }
    }
}
