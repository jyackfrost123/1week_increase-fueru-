using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PranariaControler : MonoBehaviour
{

    public GameObject pranariaChild;

    public drawPhys2 phys;

    float expand = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        phys = GameObject.Find("line").GetComponent<drawPhys2>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.localScale += this.transform.localScale/600.0f;
    }

    


    /*void OnCollisionEnter2D(Collision2D other){
        Debug.Log("Death!!!");
        if(other.gameObject.tag == "Plane" ){

         Instantiate(pranariaChild, other.transform.position + new Vector3(0.1f,0.1f,0), Quaternion.identity);
        Instantiate(pranariaChild, other.transform.position + new Vector3(-0.1f,-0.1f,0), Quaternion.identity);

          //Instantiate(SEprefabs[i], this.transform.position, Quaternion.identity);

            

            Destroy(this.gameObject);

        }
    }*/


    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Death!!!");
        if(other.gameObject.tag == "Plane"  && phys.isCut == true){

        GameObject obj = Instantiate(pranariaChild, this.transform.position + GetComponent<SpriteRenderer>().bounds.size/2.0f, Quaternion.identity);
        obj.transform.localScale = this.transform.localScale / 2.0f;
        GameObject obj2 = Instantiate(pranariaChild, this.transform.position - GetComponent<SpriteRenderer>().bounds.size/2.0f, Quaternion.identity);
        obj2.transform.localScale = this.transform.localScale / 2.0f;
          //Instantiate(SEprefabs[i], this.transform.position, Quaternion.identity);

            

            Destroy(this.gameObject);

        }
    }



}
