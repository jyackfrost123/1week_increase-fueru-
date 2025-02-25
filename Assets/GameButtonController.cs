using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtonController : MonoBehaviour
{

   // ParametorController para;
   SceneParameterController para;
   UIController ui;
    
    
    void Start()
    {

        para = GameObject.Find("NCMBSettings").GetComponent<SceneParameterController>(); 

       //para = GameObject.Find("Canvas").GetComponent<ParametorController>(); 7
       ui = GetComponent<UIController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void goTweet(){//Scene2
       naichilab.UnityRoomTweet.Tweet ("fuermata", (ui.score/10)+"匹ノ”フェルマータ”ヲ導イタ！  ｱﾘｶﾞﾄｳ!  (・)  /・\\  |・| ", "unity1week", "Fuermata");
    }

    public void go2ndTweet(){
        naichilab.UnityRoomTweet.Tweet ("fuermata", (ui.score)+"点ノ”フェルマータ”ヲ導イタ！  ｱﾘｶﾞﾄｳ!  (・)  /・\\  |・| ", "unity1week", "Fuermata");
    }

    public void goPictureTweet(){
        //StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("フェルマータ”ト遊ンダ！  ﾜｰｲ! (・)  "+"ゲームのURL: https://bit.ly/3h4H9QM "+"画像のURL:") );//+   
    }

    public void goRanking(){//Scene2
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.score);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (ui.score, 0);
    }

    public void go2ndRanking(){//Scene4
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking (para.score);
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (ui.score, 1);
    }

    /*public void goRankingShow(){
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking (0);
    }*/

    public void ReStart(){//Scene2
        //SceneManager.LoadScene("MainScene");
        FadeManager.Instance.LoadScene ("GameScine2", 2.0f);
    }

    public void Re2ndStart(){//Scene4
        //SceneManndager.LoadScene("MainScene");
        FadeManager.Instance.LoadScene ("GameScine4", 2.0f);
        
    }

    public void goTitle(){
        FadeManager.Instance.LoadScene ("Opning", 2.0f);
    }

    public void geAfterTutorial(){
        if(para.loadNum == 0){
           FadeManager.Instance.LoadScene ("GameScine2", 2.0f);
        }else{
           FadeManager.Instance.LoadScene ("GameScine4", 2.0f);
        }

        para.isFirst = false;
    }
 
}
