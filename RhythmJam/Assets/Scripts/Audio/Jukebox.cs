using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Jukebox : MonoBehaviour
{
    [Header("Audio Components")]
    [SerializeField] private AudioMixer m_MasterMixer;
    [SerializeField] private AudioSource m_Output = null;

    [Header("Jukebox")]
    [SerializeField] private bool m_TrackIsPlaying = false; //Checks if a track is playing.
    [SerializeField] private int m_CurrentTrack = 0;        //Indicates which track is playing.
    [SerializeField] private int m_BPM = 0;                 //The BPM/tempo of the song.

    [Header("Tracks")]
    [SerializeField] private AudioClip m_TitleScreenBGM = null;
    [SerializeField] private AudioClip m_Track1 = null;
    [SerializeField] private AudioClip m_Track2 = null;
    [SerializeField] private AudioClip m_Track3 = null;
    [SerializeField] private bool[] m_AllTracks;            //Bool to check which track is playing.

    [Header("Fade In & Out")]
    [SerializeField] private float m_Timer = 1.5f;
    [SerializeField] private float m_CurrentTime;

    private static Jukebox instance;

    public static Jukebox Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Jukebox>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<Jukebox>();
                    singleton.name = "(Singleton) Jukebox";
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    //Each of the following integers corresponds to a track that can be played. 
    //0 - Title Screen
    //1 - Track 1
    //2 - Track 2
    //3 - Track 3

    void Start()
    {
        Instance.PlayTrack(0);
        m_CurrentTime = m_Timer;
    }

    void Update()
    {
        //DEBUG INPUT - REMOVE AFTER SUCCESSFUL TESTS
        if (Input.GetKeyDown("0"))
        {
            PlayTrack(0);
            //Debug.Log("Initiate Title Screen BGM.");
        }
        else if (Input.GetKeyDown("1"))
        {
            PlayTrack(1);
            //Debug.Log("Initiate Track 1.");
        }
        else if (Input.GetKeyDown("2"))
        {
            PlayTrack(2);
            //Debug.Log("Initiate Track 2.");
        }
        else if (Input.GetKeyDown("3"))
        {
            PlayTrack(3);
            //Debug.Log("Initiate Track 3.");
        }
    }

    public void PlayTrack(int Track)
    {
        if (Track == 0)
        {
            StopTrack();
            gameObject.GetComponent<AudioSource>().clip = m_TitleScreenBGM;
            m_CurrentTrack = 0;
            m_AllTracks[m_CurrentTrack] = true;
            m_BPM = 0;

            m_Output.PlayDelayed(0.5f);
        }
        else if (Track == 1 && m_CurrentTrack != 1)
        {
            StopTrack();
            gameObject.GetComponent<AudioSource>().clip = m_Track1;
            m_CurrentTrack = 1;
            m_AllTracks[m_CurrentTrack] = true;
            m_BPM = 120;        //Change to whatever the actual BPM is once we get to it.

            gameObject.GetComponent<AudioSource>().volume = 0.3f;   //Temporary to no kill our ears while testing. The final songs and SFX should be mixed properly.
            m_Output.PlayDelayed(2.0f);                             //Might substitute the delay with Play() when the real songs are in (with countdown).
        }
        else if (Track == 2 && m_CurrentTrack != 2)
        {
            StopTrack();
            gameObject.GetComponent<AudioSource>().clip = m_Track2;
            m_CurrentTrack = 2;
            m_AllTracks[m_CurrentTrack] = true;
            m_BPM = 140;        //Change to whatever the actual BPM is once we get to it.

            m_Output.PlayDelayed(2.0f);
        }
        else if (Track == 3 && m_CurrentTrack != 3)
        {
            StopTrack();
            gameObject.GetComponent<AudioSource>().clip = m_Track3;
            m_CurrentTrack = 3;
            m_AllTracks[m_CurrentTrack] = true;
            m_BPM = 160;        //Change to whatever the actual BPM is once we get to it.

            m_Output.PlayDelayed(2.0f);
        }

        m_TrackIsPlaying = true;

    }

    public void StopTrack()
    {
        if (m_CurrentTrack == 0)
        {
            //SoundManager.Instance.BGM_Stop("m_BGM_TitleScreen_Stop");
            m_AllTracks[0] = false;
        }
        else if (m_CurrentTrack == 1)
        {
            //SoundManager.Instance.BGM_Stop("m_BGM_Exploration_Neutral_Stop");
            m_AllTracks[1] = false;
        }
        else if (m_CurrentTrack == 2)
        {
            //SoundManager.Instance.BGM_Stop("m_BGM_Exploration_Eerie_Stop");
            m_AllTracks[2] = false;
        }
        else if (m_CurrentTrack == 3)
        {
            //SoundManager.Instance.BGM_Stop("m_BGM_Exploration_Eerie_Stop");
            m_AllTracks[3] = false;
        }

        m_Output.Stop();
    }

    void FadeOut()
    {

    }
}
