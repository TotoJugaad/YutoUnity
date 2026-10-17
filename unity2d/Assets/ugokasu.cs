using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class ugokasu : MonoBehaviour
{
    public List<SplineContainer> splines = new List<SplineContainer>(){
        null,
        null
    };

    
    public Transform target;
    public float speed = 1f;

    private float t = 0f;
    private int line = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        t += speed * Time.deltaTime;

        if (t > 1f){
            line += 1;
            if(line>=splines.Count)line=0;
            t = 0f;
        }// roop
        Vector3 pos;
        pos = splines[line].EvaluatePosition(line >= 3 ? 1 - t : t);
        
        target.position = new Vector3(pos.x, pos.y, 0);


        // set the rotation
        //Vector3 direction = spline.EvaluateTangent(t);
        //transform.right = direction;
    }
}
