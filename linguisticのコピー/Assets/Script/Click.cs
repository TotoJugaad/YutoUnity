using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    [System.NonSerialized] public bool furagu = false;
    [System.NonSerialized] public int Chiiki;
    public void StartClick()
    {
        PlayerPrefs.SetString("IFClick", "true");
         PlayerPrefs.Save();
        PlayerPrefs.SetInt("Chiiki", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Quiz");
    }
    public void HammerClick()
    {
        PlayerPrefs.SetString("IFClick", "true");
        PlayerPrefs.SetInt("Chiiki", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Quiz");
    }
    public void Back()
    {
        SceneManager.LoadScene("Start");
    }
    public void Next()
    {
        furagu = false;
    }
}
