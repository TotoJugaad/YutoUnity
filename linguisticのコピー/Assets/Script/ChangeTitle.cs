using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeTitle : MonoBehaviour
{
    public Text tIt1e;
    bool tochu = true;
    public Font nomalFont;
    public TextMeshProUGUI adfa;
    string[] tit1e = new string[]
    {
        "World language Quiz",
        "Quiz langues du monde",
        "Quiz lingue del mondo",
        "Cuestionario lenguas\n\ndel mundo",
        "Викторина по\n\nмировому xязыку",
        "Вікторина з\n\nпомірної мови"
    };
    // Start is called before the first frame update
    void Start()
    {
        tIt1e.font = nomalFont;
    }

    // Update is called once per frame
    void Update()
    {
        if (tochu) { tochu = false; StartCoroutine(tIt1eChange()); }
    }
    IEnumerator tIt1eChange()
    {
        
        for (int i = 0; i < 7; i++)
        {
            adfa.enabled = true;
            if (i >= 3)
            {
                adfa.enabled = false;
            }
            
            tIt1e.text = tit1e[i];
            yield return new WaitForSeconds(2);
        }
        tochu = true;
    }
}
