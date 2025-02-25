using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpningMinionsController : MonoBehaviour
{


    private Rigidbody2D rb2D;
    public float thrust = 10.0f;

    public GameObject childrenObject;
    int i = 0;

    public bool isStand = false;
    float startX;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        startX = this.transform.position.x;
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
 
    
         RaycastHit hit;
         Ray ray = new Ray(this.transform.position + Vector3.up, Vector3.down);

       if (Physics.Raycast(ray, out hit, 2.0f))
       {
        float offset = this.transform.position.y - hit.point.y;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - offset, this.transform.position.z);
       }
    


       if(isStand == true){
          rb2D.AddForce(transform.right * thrust);
        }
       
       

       if(this.transform.position.y <= -6.0f || this.transform.position.x >= 9.0f ){
           Instantiate( childrenObject,  new Vector3(Random.Range(-9.0f, 9.0f), 10.0f, 0.0f), Quaternion.identity);
           Destroy(this.gameObject);
        //transform.position = new Vector3(startX, 10.0f, 0.0f);
        
       }

    }

  



    void OnCollisionEnter2D(Collision2D other){
        
        if( isStand != true && other.gameObject.tag == "Plane" ){
            isStand = true;
        }
        
    }







}
