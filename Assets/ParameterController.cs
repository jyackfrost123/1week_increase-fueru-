using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterController : MonoBehaviour
{

    public int score;

    public float volume;

    private static ParameterController instance = null; // boxインスタンスの実体

    public static ParameterController Instance => instance   // boxインスタンスのプロパティーは、実体が存在しないとき（＝初回参照時）実体を探して登録する
       ?? ( instance = GameObject.FindWithTag ("Parameter").GetComponent<ParameterController> () );


    void Awake(){
        if ( this != Instance ) //新規に作成されてしまったオブジェクトの破壊
        {
            Destroy ( this.gameObject );
            return;
        }

    	DontDestroyOnLoad(gameObject);
        
        
        volume = 1.0f;
        
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
