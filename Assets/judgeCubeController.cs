using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class judgeCubeController : MonoBehaviour
{

    UIController ui;
    public int judgeType;

    public bool isUnderground = false;


    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<UIController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

/*
    void OnCollisionEnter2D(Collision2D other){
        
        if( other.gameObject.tag == "Minions" ){
            //isStand = true;

           if( other.gameObject.GetComponent<minionsController>().minionType == judgeType){
               ui.addScore();
           }else{
               ui.lifeReduce();
           }


            //normalVector = other.contacts[0].normal;

            /*if(anime.isAnimation == false){
                anime.isAnimation = true;
            }*/
           
 //       }

        //vect = other.gameObject.transform.position;
        
//    }


        void OnTriggerEnter2D(Collider2D other){
        
        if( other.gameObject.tag == "Minions" ){
            //isStand = true;

           if( other.gameObject.GetComponent<minionsController>().minionType == judgeType){
               ui.addScore();
           }else{

               if(ui.isTime == false){
                   ui.lifeReduce();
               }else if(isUnderground == true){
                   ui.reduceScore();
               }else{
                   ui.miniAddScore();
               }

           }


            //normalVector = other.contacts[0].normal;

            /*if(anime.isAnimation == false){
                anime.isAnimation = true;
            }*/
           
        }

        //vect = other.gameObject.transform.position;
        
    }

}
