using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{


    /*https://qiita.com/lycoris102/items/5d5359b2015a8fdebaaa */

    /*
    bool changing = false;

    int musicNumber = 0;

    public float fadeTime;

    public float musicVolume;
    */

    private AudioSource playingSource;

    //ParameterController para;


    //public AudioClip[] musicLayout;


    void Awake(){
        playingSource = GetComponent<AudioSource>();
       // para = GameObject.Find("ParameterController").GetComponent<ParameterController>();
        //playingSource.clip = musicLayout[musicNumber];
    }

    void Start(){
        //playingSource.volume = 0.5f * para.volume;
    }

    // Update is called once per frame
    void FixedUpdate(){
        //playingSource.volume = 0.5f * para.volume;
    }

    public void Play(){
         playingSource.Play();
    }


}
