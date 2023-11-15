using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{
    public BirdScript bird;
    public AudioSource BGMusic;
    // Start is called before the first frame update
    void Start()
    {
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
        BGMusic = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bird.birdIsAlive == false)
        {
            BGMusic.Stop();
        }

        if(Time.timeScale > 0)
        {
            BGMusic.UnPause();
        }else
        {
            BGMusic.Pause();
        }
    }
}
