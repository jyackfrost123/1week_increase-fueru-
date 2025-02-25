using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStopController : MonoBehaviour
{
    // Start is called before the first frame update

    //This used by SE 

    private AudioSource playingSource;

    ParameterController para;


    void Start()
    {
         playingSource = GetComponent<AudioSource>();
         //para = GameObject.Find("ParameterController").GetComponent<ParameterController>();
         playingSource.volume = 0.5f;
         playingSource.Play();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //playingSource.volume = 0.5f * para.volume;

        if(!playingSource.isPlaying){
            Destroy(this.gameObject);
        }
    }
}
