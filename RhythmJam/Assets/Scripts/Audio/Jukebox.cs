using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Jukebox : MonoBehaviour
{
    [Header("Jukebox")]
    [SerializeField] private AudioSource m_Output = null;
    [SerializeField] private bool m_TrackIsPlaying = false; //Checks if a track is playing.
    [SerializeField] private int m_CurrentTrack = 0;        //Indicates which track is playing.
    [SerializeField] private int m_BPM = 0;                 //The BPM/tempo of the song.

    [Header("Tracks")]
    [SerializeField] private AudioClip m_TitleScreenBGM = null;
    [SerializeField] private AudioClip m_Track1 = null;
    [SerializeField] private AudioClip m_Track2 = null;
    [SerializeField] private AudioClip m_Track3 = null;
    [SerializeField] private bool[] m_AllTracks;            //Bool to check which track is playing.

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
    }

    void Update()
    {

    }

    void PlayTrack(int Track)
    {
        if (Track == 0)
        {
            //StopTrack();
            m_CurrentTrack = 0;
            m_AllTracks[m_CurrentTrack] = true;
            m_BPM = 0;
        }
        else if (Track == 1 && m_CurrentTrack != 1)
        {
            //StopTrack();
            //SoundManager.Instance.BGM_Start("m_BGM_TitleScreen");
            m_Output.GetComponent<>
            m_CurrentTrack = 1;
            m_AllTracks[m_CurrentTrack] = true;
            m_BPM = 120;        //Change to whatever the actual BPM is once we get to it.
        }
        else if (Track == 2 && m_CurrentTrack != 2)
        {
            //StopTrack();
            //SoundManager.Instance.BGM_Start("m_BGM_Exploration_Neutral");
            m_CurrentTrack = 2;
            m_AllTracks[m_CurrentTrack] = true;
            m_BPM = 120;        //Change to whatever the actual BPM is once we get to it.
        }
        else if (Track == 3 && m_CurrentTrack != 3)
        {
            //StopTrack();
            //SoundManager.Instance.BGM_Start("m_BGM_Exploration_Eerie");
            m_CurrentTrack = 3;
            m_AllTracks[m_CurrentTrack] = true;
            m_BPM = 120;        //Change to whatever the actual BPM is once we get to it.
        }

        m_TrackIsPlaying = true;
    }

    void StopTrack()
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
    }
}
