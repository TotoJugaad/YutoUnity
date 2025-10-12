using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSize : MonoBehaviour
{
    public float saiz = 3.0f;
    [HideInInspector]public Vector3 vecSaiz;
    // Start is called before the first frame update
    void Start()
    {
        vecSaiz = new Vector3(1.05f / saiz, 1, 1.05f / saiz);
        transform.localScale = new Vector3(vecSaiz.x, vecSaiz.y, vecSaiz.z);
        Debug.Log(1.05f/saiz);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
