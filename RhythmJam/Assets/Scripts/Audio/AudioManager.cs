using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    [Header("Audio Components")]
    [SerializeField] private AudioMixer m_MasterMixer = null;
    [SerializeField] private AudioSource m_Output = null;

    [Header("SFX Audio Clips")]
    [SerializeField] private AudioClip m_Button_Hover = null;
    [SerializeField] private AudioClip m_Button_Select= null;
    [SerializeField] private AudioClip m_Button_Back = null;
    [Space(10)]
    [SerializeField] private AudioClip m_Pause = null;
    [SerializeField] private AudioClip m_Unpause = null;
    [Space(10)]
    [SerializeField] private AudioClip m_Note_Perfect = null;
    [SerializeField] private AudioClip m_Note_Good = null;
    [SerializeField] private AudioClip m_Note_Bad = null;
    [SerializeField] private AudioClip m_Note_Miss = null;


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

    public void SFX_Button(string Action)
    {
        if(Action == "Hover")
        {
            m_Output.PlayOneShot(m_Button_Hover);
        }
        else if(Action == "Select")
        {
            m_Output.PlayOneShot(m_Button_Select);
        }
        else if(Action == "Back")
        {
            m_Output.PlayOneShot(m_Button_Back);
        }
    }

    public void SFX_Note(int Accuracy)
    {
        if(Accuracy == 3)
        {
            m_Output.PlayOneShot(m_Note_Perfect);
        }
        else if(Accuracy == 2)
        {
            m_Output.PlayOneShot(m_Note_Good);
        }
        else if(Accuracy == 1)
        {
            m_Output.PlayOneShot(m_Note_Bad);
        }
        else if (Accuracy == 0)
        {
            m_Output.PlayOneShot(m_Note_Miss);
        }
    }
}
