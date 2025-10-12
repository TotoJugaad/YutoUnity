using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Scriptable_Flag")]

public class ImageList : ScriptableObject
{
    public List<Sprite> Asia = new List<Sprite>();
    public List<Sprite> Europe = new List<Sprite>();
    public List<Sprite> America = new List<Sprite>();
    public List<Sprite> Africa = new List<Sprite>();
    public List<Sprite> ITL = new List<Sprite>();
    public List<Sprite> USSR = new List<Sprite>();
}