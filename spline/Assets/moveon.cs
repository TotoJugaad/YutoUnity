using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class moveon : MonoBehaviour
{
    public SplineContainer target;
    public float speed = 1f;

    private float t = 0f;
    //private int line = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += speed * Time.deltaTime; 

        Vector3 pos;
        pos = target.EvaluatePosition(t);
        
        transform.position = new Vector3(pos.x, pos.y, 0);
        // set the rotation
        //Vector3 direction = spline.EvaluateTangent(t);
        //transform.right = direction;
    }
}
