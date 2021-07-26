using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start_Screen : MonoBehaviour
{
    Animator m_Start_Screen_Animator;

    [Header("Current Screen")]
    [SerializeField] private bool m_StartScreen;
    [SerializeField] private bool m_TrackSelection;
    [SerializeField] private bool m_Options;

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
        m_StartScreen = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape") && m_StartScreen == false)
        {
            Instance.BackIsClicked();
        }
    }

    public void StartIsClicked()
    {
        m_Start_Screen_Animator.SetBool("StartIsClicked", true);
        m_Start_Screen_Animator.SetBool("BackIsClicked", false);
        m_Start_Screen_Animator.SetBool("OptionIsClicked", false);

        m_StartScreen = false;
        m_TrackSelection = true;
        m_Options = false;
    }

    public void BackIsClicked()
    {
        m_Start_Screen_Animator.SetBool("StartIsClicked", false);
        m_Start_Screen_Animator.SetBool("BackIsClicked", true);
        m_Start_Screen_Animator.SetBool("OptionIsClicked", false);

        m_StartScreen = true;
        m_TrackSelection = false; 
    }

    public void OptionsIsClicked()
    {
        m_Start_Screen_Animator.SetBool("StartIsClicked", false);
        m_Start_Screen_Animator.SetBool("BackIsClicked", false);
        m_Start_Screen_Animator.SetBool("OptionIsClicked", true);

        m_StartScreen = false;
        m_TrackSelection = false;
        m_Options = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
