using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class aaaaa : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public void 
    public void ChangeToScene(string sceneName)
    {
        Debug.Log("Changing scene to: " + sceneName);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
