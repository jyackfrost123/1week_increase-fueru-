using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int r = Random.Range(0, 4);//0,1,2,3

        if(r == 0){
            transform.Translate(0.0f, 0.1f, 0.0f);
        }else if(r == 1){
            transform.Translate(0.0f, -0.1f, 0.0f);
        }
            transform.Translate(0.01f, 0.0f, 0.0f);
        
    }
}
