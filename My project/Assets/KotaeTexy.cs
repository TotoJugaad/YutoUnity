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
    [System.NonSerialized] public string[] KokkiMeiITL = new string[]
    {
        "神萘・イスラム連邦\n(旧漢和民主主義人民連邦共和国)",
        "ブルナクール及びサニー連合国",
        "カカニ",
        "カカニ領メチヤ",
        "ホマニトーイ特別行政区",
        "ジュガール・イスラム連邦\n社会主義民主人民共和国"
    };
    [System.NonSerialized] public string[] KokkiMeiAfrica;
    [System.NonSerialized] public string[] KokkiMeiAmerica;
    [System.NonSerialized] public string[] KokkiMeiEurope;
    [System.NonSerialized] public string[] KokkiMeiAsia = new string[]
    {
        "日本国"
    };
    [System.NonSerialized]public string[] KokkiMeiUSSR = new string[]
    {
        "ソビエト社会主義\n共和国連邦",
        "ロシア\nソビエト連邦社会主義共和国",
        "ウクライナ\nソビエト社会主義共和国",
        "ベラルーシ\nソビエト社会主義共和国",
        "ウズベク\nソビエト社会主義共和国",
        "カザフ\nソビエト社会主義共和国",
        "アゼルバイジャン\nソビエト社会主義共和国",
        "リトアニア\nソビエト社会主義共和国",
        "ラトビア\nソビエト社会主義共和国",
        "キルギス\nソビエト社会主義共和国",
        "タジク\nソビエト社会主義共和国",
        "アルメニア\nソビエト社会主義共和国",
        "トルクメン\nソビエト社会主義共和国",
        "エストニア\nソビエト社会主義共和国"
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
        switch (listName)
        {
            case "ITL":
                Kotae.text = "正解は: " + KokkiMeiITL[kokkiKazu];
                listLength = KokkiMeiITL.Length;
                break;
            case "Africa":
                Kotae.text = "正解は: " + KokkiMeiAfrica[kokkiKazu];
                listLength = KokkiMeiAfrica.Length;
                break;
            case "America":
                Kotae.text = "正解は: " + KokkiMeiAmerica[kokkiKazu];
                listLength = KokkiMeiAmerica.Length;
                break;
            case "Europe":
                Kotae.text = "正解は: " + KokkiMeiEurope[kokkiKazu];
                listLength = KokkiMeiEurope.Length;
                break;
            case "Asia":
                Kotae.text = "正解は: " + KokkiMeiAsia[kokkiKazu];
                listLength = KokkiMeiAsia.Length;
                break;
            case "USSR":
                Kotae.text = "正解は: " + KokkiMeiUSSR[kokkiKazu];
                listLength = KokkiMeiUSSR.Length;
                break;
        }
    }
}
