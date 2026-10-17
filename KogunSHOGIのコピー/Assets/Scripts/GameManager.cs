using UnityEngine;  
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Toggle BLBishopToggle;
    public Toggle CJKnightToggle;
    public Toggle PIPawnToggle;
    public Toggle TSTRookToggle;
    public Toggle AItemsToggle;

    public bool BLBishop = true;
    public bool CJKnight = true;
    public bool PIPawn = true;
    public bool TSTRook = true;
    public bool AItems = true;
    
    public void ChangeToScene(string sceneName)
    {
        Debug.Log("Changing scene to: " + sceneName);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    public void ChangeBooleanValue(string variableName)
    {
        switch (variableName)
        {
            case "BLBishop":
                BLBishop = !BLBishop;
                BLBishopToggle.isOn = BLBishop;
                break;

            case "CJKnight":
                CJKnight = !CJKnight;
                CJKnightToggle.isOn = CJKnight;
                break;

            case "PIPawn":
                PIPawn = !PIPawn;
                PIPawnToggle.isOn = PIPawn; 
                break;
                
            case "TSTRook":
                TSTRook = !TSTRook;
                TSTRookToggle.isOn = TSTRook;
                break;

            case "AItems":
                AItems = !AItems;
                AItemsToggle.isOn = AItems;
                break;
                
            default:
                Debug.LogWarning("Variable name not recognized: " + variableName);
                break;
        }
    }
}
