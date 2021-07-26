using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerLevels : MonoBehaviour
{
    //get the music from the scene and attach
    public AudioSource currentLevelMusic;

    //start the music
    public bool startPlayingMusic;

    //referencing the beatScroller script
    public BeatScroller theBeatScroller;

    //referencing this to make sure there is only one instance at a time
    public static GameManagerLevels instance;

    public int currentScore;
    public int scorePerNote = 100;

    public Text scoreText;
    public Text multiText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlayingMusic)
        {
            if (Input.anyKeyDown)
            {
                startPlayingMusic = true;
                

                currentLevelMusic.Play();
            } else
            {

            }
        }
    }

    public void noteHit()
    {
        Debug.Log("Hit");
        currentScore = currentScore + scorePerNote;
        scoreText.text = "Score: " + currentScore;
    }

    public void noteMissed()
    {
        Debug.Log("Miss");
    }
}
