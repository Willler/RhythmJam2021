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
    public int scorePerGoodNote = 150;
    public int scorePerPerfectNote = 200;

    //UI Text Elements
    public Text scoreText;
    public Text multiText;

    public static int multiplierTracker;
    public static int currentMultiplier;
    public int[] multiplierThreshold;

    public SpriteRenderer romanImage;
    private float imageClarity = 0;


    public GameObject normalNoteLight;
    public GameObject goodNoteLight;
    public GameObject perfectNoteLight;
    

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

        imageClarity += 0.01f;
        romanImage.color = new Color(255f, 255f, 255f, imageClarity);
         
    }

    ///You can add the sound effects here

    public void NormalHit()
    {
        currentScore += scorePerNote * currentMultiplier;
        StartCoroutine(normalNote());
        noteHit();

        AudioManager.Instance.SFX_Note(1);
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        StartCoroutine(goodNote());
        noteHit();

        AudioManager.Instance.SFX_Note(2);
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        StartCoroutine(PerfectNote());
        noteHit();

        AudioManager.Instance.SFX_Note(3);
    }

    ///This doesn't do anything anymore
    public void noteMissed()
    {
        //Debug.Log("Miss");

    }

    

    IEnumerator normalNote()
    {
        normalNoteLight.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        normalNoteLight.SetActive(false);
    }

    IEnumerator goodNote()
    {
        goodNoteLight.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        goodNoteLight.SetActive(false);
    }

    IEnumerator PerfectNote()
    {
        perfectNoteLight.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        perfectNoteLight.SetActive(false);
    }
}
