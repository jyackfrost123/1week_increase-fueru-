using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweetButtonsCOntroller : MonoBehaviour
{

    drawPhysicsLine line;
    // Start is called before the first frame update
    void Start()
    {
        line = GameObject.Find("line").GetComponent<drawPhysicsLine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goPictureTweet(){
        StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot("”フェルマータ”ト遊ンダ！  ﾜｰｲ! (・)  "+"　ゲーム：『fuer mata ~フエルマータ~ - 竹ふくろう』") );//+   
    }
}
