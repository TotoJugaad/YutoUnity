using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KotaeTexy : MonoBehaviour
{
    public int listLength;
    public Text Kotae;
    public int kokkiKazu;
    public string listName;
    [System.NonSerialized] public string[] GengoMei = new string[]
    {
        "英語",
        "フランス語",
        "スペイン語",
        "イタリア語",
        "ロシア語",
        "ウクライナ語",
        "エスペラント",
        "日本語"
    };

    private void Start()
    {
        Kotae.enabled = false;
    }
    public void namaeNull()
    {
        Kotae.text = "";
    }

    public IEnumerator WaitForSpacePressCoroutine()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        Kotae.enabled = true;
        Kotae.text = "正解は：" + GengoMei[kokkiKazu];
        listLength = GengoMei.Length;
    }
    public void kotaeHyoji()
    {
        Kotae.enabled = true;
        Kotae.text = "正解は：" + GengoMei[kokkiKazu];
        listLength = GengoMei.Length;
    }
}
