using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    [Header("Audio Components")]
    [SerializeField] private AudioMixer m_MasterMixer;
    [SerializeField] private AudioSource m_Output = null;

    [Header("SFX Audio Clips")]
    [SerializeField] private AudioClip m_Button_Hover;
    [SerializeField] private AudioClip m_Button_Click;
    [Space(10)]
    [SerializeField] private AudioClip m_Pause;
    [SerializeField] private AudioClip m_Unpause;
    [Space(10)]
    [SerializeField] private AudioClip m_Note_Success;
    [SerializeField] private AudioClip m_Note_Miss;


    private static AudioManager instance;

    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<AudioManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<AudioManager>();
                    singleton.name = "(Singleton) AudioManager";
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        //DEBUG INPUT - REMOVE AFTER SUCCESSFUL TESTS
        if (Input.GetKeyDown("7"))
        {
            PlaySFX(0);
        }
        else if (Input.GetKeyDown("8"))
        {
            PlaySFX(1);
        }
    }

    public void MasterVol(float MasterSlider)
    {
        m_MasterMixer.SetFloat("m_MasterVol", Mathf.Log10(MasterSlider) * 20);
    }

    public void MusicVol(float MusicSlider)
    {
        m_MasterMixer.SetFloat("m_MusicVol", Mathf.Log10(MusicSlider) * 20);
    }

    public void SFXVol(float SFXSlider)
    {
        m_MasterMixer.SetFloat("m_SFXVol", Mathf.Log10(SFXSlider) * 20);
    }

    public void PlaySFX(int SFX)
    {
        if(SFX == 0)
        {
            gameObject.GetComponent<AudioSource>().clip = m_Button_Hover;
        }
        else if(SFX == 1)
        {
            gameObject.GetComponent<AudioSource>().clip = m_Button_Click;
        }

        m_Output.Play();
    }
}
