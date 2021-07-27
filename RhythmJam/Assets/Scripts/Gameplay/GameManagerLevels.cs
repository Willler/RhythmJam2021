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

    //numerical score variables
    public static int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    //UI Text Elements
    public Text scoreText;
    public Text multiText;

    public static int multiplierTracker;
    public static int currentMultiplier;
    public int[] multiplierThreshold;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        scoreText.text = "000";
        currentMultiplier = 1;
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

        if (currentMultiplier - 1 < multiplierThreshold.Length)
        {
            multiplierTracker++;

            if (multiplierThreshold[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        multiText.text = currentMultiplier + "x";

        //currentScore = currentScore + scorePerNote * currentMultiplier;
        scoreText.text = "" + currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        noteHit();
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        noteHit();
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        noteHit();
    }


    public void noteMissed()
    {
        //Debug.Log("Miss");
    }
}
