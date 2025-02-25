using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineController : MonoBehaviour
{
    // Start is called before the first frame update

    public List<Vector3> points = new List<Vector3>();

    public GameObject needle;

    LineRenderer renderer;

    void Start () {
     renderer = gameObject.GetComponent<LineRenderer>();
     // 線の幅
     renderer.SetWidth(0.1f, 0.1f);

    }
        
    

    // Update is called once per frame
    void FixedUpdate()
    {
     
     points.Add(needle.transform.position);
     // 頂点の数
     renderer.SetVertexCount(points.Count);
     // 頂点を設定
     //renderer.SetPosition(0, Vector3.zero);
     //renderer.SetPosition(1, new Vector3(1f, 1f, 0f));
     for(int i=0; i<points.Count; i++){
        renderer.SetPosition(i, points[i]); 
     }


     //renderer.SetPosition(points.Count, needle.transform.position);


    }
}
