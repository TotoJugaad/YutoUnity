using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManger : MonoBehaviour
{
    public GameObject plane;
    public GameObject line;
    public int saiz = 3;
    public float position;
    [HideInInspector] public Vector3 vecSaiz;
    // Start is called before the first frame update
    void Start()
    {
        position = (saiz - 1) / 2;
        for (int i = 0; i < saiz; i++)
        {
            for (int j = 0; j < saiz; j++)
            {
                Instantiate(plane, new Vector3((i - position) * 3.5f, 0.001f, (j - position) * 3.5f), Quaternion.identity);
            }
        }
        for(int i = 0; i < saiz + 1; i++)
        {
            for(int j = 0; j < saiz + 1; j++)
            {
                Instantiate(line, new Vector3(1, 0.002f,1), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
