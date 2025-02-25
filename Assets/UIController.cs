using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using unityroom.Api;

public class UIController : MonoBehaviour
{
    Text scoreText;
    Text startText;
    //Text destroyText;
    //Text gameOverText;
    //Text finalText;
    //Text timeText;

    public int life = 10;

    public int score = 0;

    public bool gameStart = false;
    bool uiStart = false;

    public float startTime = 4.9f;

    public bool gameOver = false;

    //public int muchPoint = 20;
    public int point = 10;


    public Image[] sprites;
    public Sprite deathSprite;

    public GameObject[] gameOverObjects;


    public bool isTime = false;
    public float timeLimit = 60.0f;
    Text timeText;

    public GameObject SE;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        startText = GameObject.Find("StartText").GetComponent<Text>();

        if(isTime == true){
            timeText= GameObject.Find("timeText").GetComponent<Text>();
        }
        
        for(int i=0; i<gameOverObjects.Length; i++){
                gameOverObjects[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = "Score："+score+"点";

        if(uiStart == false){
            startTime -= Time.deltaTime;

            if(startTime < 1.0f){
                startText.text = "Start!";
                gameStart = true;

                if(startTime <= 0.0f){
                    startText.text = "";
                    uiStart = true;
                }
            }else{
               startText.text = ( (int) startTime ).ToString();
            }

        }

        if(gameStart == true && isTime == true){

            if(gameOver != true){
              timeLimit -= Time.deltaTime;
            }
            timeText.text = ( (int) timeLimit ).ToString();

            if(timeLimit <= 0.0f && gameOver == false){
              gameOver = true;
              timeLimit = 0.0f;
              for(int i=0; i<gameOverObjects.Length; i++){
                gameOverObjects[i].SetActive(true);
              }
              //TODO:ランキング呼び出し処理
              UnityroomApiClient.Instance.SendScore(1, score, ScoreboardWriteMode.HighScoreDesc);
            }
        }
    }

    public void addScore(){
        if(gameOver != true){
         score += point;
        }
        /*if(){
            score += muchPoint;
        }*/

    }

    public void miniAddScore(){
        if(gameOver != true){
         score += point/2;
        }
        /*if(){
            score += muchPoint;
        }*/

    }

    public void reduceScore(){
        if(gameOver != true){
         score -= point;
        }
    }

    public void lifeReduce(){
      if(life > 0 && isTime == false){
        life--;
        sprites[(sprites.Length - 1) - life].sprite = deathSprite;
        Instantiate(SE, this.transform.position, Quaternion.identity);
        if(life == 0){
            gameOver = true;
            for(int i=0; i<gameOverObjects.Length; i++){
                gameOverObjects[i].SetActive(true);
            }
            //TODO:ランキング呼び出し処理
            UnityroomApiClient.Instance.SendScore(2, score, ScoreboardWriteMode.HighScoreDesc);
        }
      }
    }

    
}
