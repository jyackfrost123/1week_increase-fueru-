using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minionsController : MonoBehaviour
{


    private Rigidbody2D rb2D;
    private AnimationController anime;
    public float thrust = 10.0f;

    public bool isStand = false;

    public Vector3 vect;
    Vector3 normalVector = Vector3.zero;

    public Vector3 onPlane;

    public  Vector3 addsVec = Vector3.zero;

    public int minionType;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anime= GetComponent<AnimationController>();
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
       

  /*     
  float distance = 100; // 飛ばす&表示するRayの長さ
  float duration = 3;   // 表示期間（秒）
           
       
         RaycastHit newhit;
         Ray newRay = new Ray(this.transform.position + new Vector3(0.7f, 3.0f, 0.0f), Vector3.down);
         Debug.DrawRay (newRay.origin, newRay.origin + newRay.direction * distance, Color.red, duration, true);
       

       if (Physics.Raycast(newRay, out newhit, distance))
       {
        //float offset = this.transform.position.y - newhit.point.y;
        //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - offset, this.transform.position.z);
        Debug.Log("newhit");
         addsVec = newhit.transform.position.normalized - (this.transform.position  - new Vector3(0.0f, 0.4f, 0.0f) );
         //addsVec = newhit.transform.position - vect;
       }
    
    */

    
       



       if(isStand == true){
          //rb2D.AddForce(addsVec * thrust);
          rb2D.AddForce(transform.right * thrust);

          //Vector3 inputVector = Vector3.zero;
    //inputVector.x = Input.GetAxis("Horizontal");
    //inputVector.z = Input.GetAxis("Vertical");
    //inputVector.x = 1.0f;
    //inputVector.y = 1.0f;
       // 平面に沿ったベクトルを計算
    
     //onPlane = Vector3.ProjectOnPlane(inputVector, normalVector);
    //onPlane = Vector3.ProjectOnPlane(normalVector, inputVector);
    //rb2D.AddForce(onPlane * thrust);

        }
       
       

       if(this.transform.position.y <= -6.0f || this.transform.position.x >= 9.0f ){
         Destroy(this.gameObject);
       }

    }

  

   /*void OnCollisionStay2D(Collision2D other){
       if(other.gameObject.tag == "Plane"){
            isStand = true;
        }
       
   }*/




    void OnCollisionEnter2D(Collision2D other){
        
        if( isStand != true && other.gameObject.tag == "Plane" ){
            isStand = true;


            normalVector = other.contacts[0].normal;

            /*if(anime.isAnimation == false){
                anime.isAnimation = true;
            }*/
           
        }
        

        //vect = other.gameObject.transform.position;
        
    }

    
    void OnCollisionStay2D(Collision2D other){
        //Debug.Log("Yes!!");
    }





}
