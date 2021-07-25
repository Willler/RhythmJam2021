using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_1_Test : MonoBehaviour
{
    Animator m_Animator;

    private static Button_1_Test instance;

    public static Button_1_Test Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Button_1_Test>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<Button_1_Test>();
                    singleton.name = "(Singleton) Button_1_Test";
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
        m_Animator = GetComponent<Animator>();
    }

    public void SongButtons()
    {
        m_Animator.SetBool("Move", true);
    }
}
