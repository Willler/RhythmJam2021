using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Screen : MonoBehaviour
{
    Animator m_Start_Screen_Animator;
    GameManager m_GameManager;

    private static Start_Screen instance;

    public static Start_Screen Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Start_Screen>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<Start_Screen>();
                    singleton.name = "(Singleton) Start_Screen";
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        m_Start_Screen_Animator = GetComponent<Animator>();
    }

    public void StartIsClicked()
    {
        m_Start_Screen_Animator.SetBool("StartIsClicked", true);
        m_Start_Screen_Animator.SetBool("BackIsClicked", false);
        m_Start_Screen_Animator.SetBool("OptionIsClicked", false);

        GameManager.Instance.m_StartScreen = false;
        GameManager.Instance.m_TrackSelection = true;
        GameManager.Instance.m_OptionsMenu = false;
    }

    public void BackIsClicked()
    {
        m_Start_Screen_Animator.SetBool("StartIsClicked", false);
        m_Start_Screen_Animator.SetBool("BackIsClicked", true);
        m_Start_Screen_Animator.SetBool("OptionIsClicked", false);

        GameManager.Instance.m_StartScreen = true;
        GameManager.Instance.m_TrackSelection = false;
        GameManager.Instance.m_OptionsMenu = false;
    }

    public void OptionsIsClicked()
    {
        m_Start_Screen_Animator.SetBool("StartIsClicked", false);
        m_Start_Screen_Animator.SetBool("BackIsClicked", false);
        m_Start_Screen_Animator.SetBool("OptionIsClicked", true);

        GameManager.Instance.m_StartScreen = false;
        GameManager.Instance.m_TrackSelection = false;
        GameManager.Instance.m_OptionsMenu = true;
    }
}
