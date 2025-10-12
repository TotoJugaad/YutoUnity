using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeTitle : MonoBehaviour
{
    public Text tIt1e;
    bool tochu = true;
    public Font nomal;
    public Font koryo;
    public TextMeshProUGUI adfa;
    string[] tit1e = new string[]
    {
        "World language Quiz",
        "Quiz langues du monde",
        "Quiz lingue del mondo",
        "세계 언어 퀴즈",
        "Cuestionario lenguas\n\ndel mundo",
        "Викторина по\n\nмировому xязыку",
        "Вікторина з\n\nпомірної мови"
    };
    // Update is called once per frame
    void Update()
    {
        if (tochu) { tochu = false; StartCoroutine(tIt1eChange()); }
    }
    IEnumerator tIt1eChange()
    {
        for (int i = 0; i < tit1e.Length; i++)
        {
            adfa.enabled = true;
            if (i > 3) { adfa.enabled = false; }
            tIt1e.font = nomal;tIt1e.fontSize = 100;
            if (i == 3){tIt1e.fontSize = 135;tIt1e.font = koryo;}
            tIt1e.text = tit1e[i];
            yield return new WaitForSeconds(2);
        }
        tochu = true;
    }
}
