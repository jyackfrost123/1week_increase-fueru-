using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionsGenerator : MonoBehaviour
{

    public float distance = 0.0f;

    public float generateDistance;

    public GameObject[] prefabs;
    public GameObject[] SEprefabs;

    public float worldGravity = 0.01f;

    public int generateNum = 3;

    public GameObject canvas;

    public UIController ui;

    public bool isTate = false;
    public bool isFree = false;
   // public bool isTime = false;
    //int scoreUpCount = 0;

    bool isFinished = false;
    public GameObject explosionPrefub;

    
    
    void Start()
    {
        Physics.gravity = new Vector3(0,worldGravity,0);

        if(canvas != null){
          ui = GameObject.Find("Canvas").GetComponent<UIController>();
          generateNum = 2;
        }
        distance = 4.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

       if(ui != null){

         if(ui.isTime == true){

           if(ui.timeLimit >= 1){
           generateNum = 2 + 5 - ( (int)ui.timeLimit / 12);
           //}else{
            // generateNum = 8;
           //}
           generateDistance = 4.25f - 1.0f / ui.timeLimit;

           if(this.transform.childCount <= 0 && ui.gameStart == true && ui.gameOver != true){
            GenerateObjects();
            distance = 0.0f;
           }
           }


         }else{

          if( 190  >=  ui.score  && ui.score > 50){//*7
            generateNum = 3;
            generateDistance = 3;
            // scoreUpCount++;
          }else if( 400 >= ui.score && ui.score > 190){//*7
           generateNum = 4;
           generateDistance = 3.5f;
          }else if( ui.score > 400){//*5

           if(this.transform.childCount <= 0 && ui.gameStart == true && ui.gameOver != true){
            GenerateObjects();
            distance = 0.0f;
           }
           //if(generateNum < 8)
           generateNum = 5 + (ui.score - 400)/ 250;
           //}else{
            // generateNum = 8;
           //}
           generateDistance = 4.00f - ( (ui.score - 400)/ 500) * 0.25f;

          }

         }


         /*if( (int)Mathf.Log( ui.score / 50 , 10) >= 1){
           generateNum = (int)Mathf.Log( ui.score / 50 , 10) ;
         }else{
           generateNum = 1;
         }*/

        if(ui.gameStart == true){
           distance += Time.deltaTime;
        }

       }

       if(isTate == true){
          distance += Time.deltaTime;
       }

        //this.speed = para.BackgroundSpeed;


        if(generateDistance <= distance ) {
          if( (ui != null && ui.gameOver != true && ui.gameStart == true)|| isTate == true){
            GenerateObjects();
            distance = 0.0f;
          }

            //distance = 0.0f;
        }

        if(explosionPrefub != null && ui.gameOver == true && isFinished == false && ui.isTime == false){
           Instantiate(explosionPrefub, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
          isFinished = true;
        }

       


        
    }

    public void GenerateObjects () {

        int i = Random.Range(0, prefabs.Length);

        if(isFree == true){
          generateNum = Random.Range(1, 9);
        }

        if(generateNum == 1){
            GameObject obj = Instantiate(prefabs[i], this.transform.position, Quaternion.identity);
            obj.transform.parent = this.transform;
            Instantiate(SEprefabs[i], this.transform.position, Quaternion.identity);

        }else if(generateNum == 2){
            GameObject obj = Instantiate(prefabs[i], this.transform.position, Quaternion.identity);
            obj.transform.parent = this.transform;
            Instantiate(SEprefabs[i], this.transform.position, Quaternion.identity);

            GameObject obj2 = Instantiate(prefabs[i], this.transform.position - new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
             obj2.transform.parent = this.transform;
            Instantiate(SEprefabs[i], this.transform.position, Quaternion.identity);

        }else if(generateNum != 0){
           GameObject obj;
          for( int j = 0; j < generateNum ; j++){
            /*
            if(j % 3 == 0){
             Instantiate(prefabs[i], this.transform.position, Quaternion.identity);
             Instantiate(SEprefabs[i], this.transform.position, Quaternion.identity);
            }else if( (j - 1) % 3 == 0){
              Instantiate(prefabs[i], this.transform.position + new Vector3(1.0f,  (j / 3) + 1.0f, 0.0f), Quaternion.identity);
              Instantiate(SEprefabs[i], this.transform.position, Quaternion.identity);
            }else{
              Instantiate(prefabs[i], this.transform.position - new Vector3(1.0f, (j / 3) +1.0f, 0.0f), Quaternion.identity);
              Instantiate(SEprefabs[i], this.transform.position, Quaternion.identity);
            }
            */

            if(j % 5 == 0 ){
              obj = Instantiate(prefabs[i], this.transform.position, Quaternion.identity);
              Instantiate(SEprefabs[i], this.transform.position, Quaternion.identity);
            }else if(j % 5 == 1){
              obj = Instantiate(prefabs[i], this.transform.position + new Vector3(1.0f,  (j / 5) + 1.0f, 0.0f), Quaternion.identity);
              Instantiate(SEprefabs[i], this.transform.position, Quaternion.identity);
            }else if(j % 5 == 2){
              obj = Instantiate(prefabs[i], this.transform.position - new Vector3(1.0f, (j / 5) +1.0f, 0.0f), Quaternion.identity);
              Instantiate(SEprefabs[i], this.transform.position, Quaternion.identity);
            }else if(j % 5 == 3){
              obj = Instantiate(prefabs[i], this.transform.position - new Vector3(2.0f, (j / 5) +1.0f, 0.0f), Quaternion.identity);
              Instantiate(SEprefabs[i], this.transform.position, Quaternion.identity);
            }else{
              obj = Instantiate(prefabs[i], this.transform.position - new Vector3(3.0f, (j / 5) +1.0f, 0.0f), Quaternion.identity);
              Instantiate(SEprefabs[i], this.transform.position, Quaternion.identity);
            }

            obj.transform.parent = this.transform;

          }

        }


        //obj.GetComponent<Rigidbody2D>().gravityScale = worldGravity;
        //worldGravity +=0.01f;

 
        //Physics.gravity = new Vector3(0,worldGravity,0);
        //GameObject obj = Instantiate(prefabs[i], this.transform.position) as GameObject;
        //obj.transform.eulerAngles = new Vector3(0,180,0);

        //0.01

    }

    /*public void GenerateObjects(){

        int i = Random.Range(0, prefabs.Length);

        if(isFree == true){
          generateNum = Random.Range(1, 9);
        }

        if(generateNum == 1){
            Instantiate(prefabs[i], this.transform.position, Quaternion.identity);
            Instantiate(SEprefabs[i], this.transform.position, Quaternion.identity);
        }else if(generateNum == 2){
            Instantiate(prefabs[i], this.transform.position, Quaternion.identity);
            Instantiate(SEprefabs[i], this.transform.position, Quaternion.identity);

            Instantiate(prefabs[i], this.transform.position - new Vector3(1.0f, 0.0f, 0.0f), Quaternion.identity);
            Instantiate(SEprefabs[i], this.transform.position, Quaternion.identity);

     
    }*/




}
