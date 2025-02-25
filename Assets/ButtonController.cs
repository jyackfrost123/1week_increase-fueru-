using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{

   SceneParameterController para;
   public GameObject[] Omakes;
    
    
    void Start()
    {
    if(GameObject.Find("NCMBSettings") != null){
         para = GameObject.Find("NCMBSettings").GetComponent<SceneParameterController>(); 

         if(para.isFirst == false){
             for(int i=0; i < Omakes.Length; i++){
                 Omakes[i].SetActive(true);
             }
         }
    }
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void goTweet(){
       // naichilab.UnityRoomTweet.Tweet ("mimira", "ミミラ様は"+para.score+"点で国を守られ、"+para.knockDown+"体の怪獣を葬った、と伝説に記されている。", "Mimira", "ahoge");
    }

    public void goRanking(){
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.score);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0, 0);
    }
    

    public void go2ndRanking(){
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0, 1);
    }

    public void ReStart(){
        //SceneManager.LoadScene("MainScene");
        if(para != null && para.isFirst == true){
            FadeManager.Instance.LoadScene ("Tutorial", 2.0f);
            //para.isFirst = false;
            para.loadNum = 0;
        }else{
          FadeManager.Instance.LoadScene ("GameScine2", 2.0f);
        }
        
    }

    public void Re2ndStart(){
        //SceneManager.LoadScene("MainScene");
        if(para != null && para.isFirst == true){
            FadeManager.Instance.LoadScene ("Tutorial", 2.0f);

            para.loadNum = 1;
        }else{
          FadeManager.Instance.LoadScene ("GameScine4", 2.0f);
        }
        
    }

    public void goTutorial(){
        FadeManager.Instance.LoadScene ("Tutorial1", 2.0f);
    }

    public void goTitle(){
        FadeManager.Instance.LoadScene ("Opning", 2.0f);
    }

    public void goFreedom(){
         FadeManager.Instance.LoadScene ("FreeMode", 2.0f);
    }
 
}
