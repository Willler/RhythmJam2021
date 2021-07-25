using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Test : MonoBehaviour
{
    Animator m_Animator;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    public void Clicked()
    {
        m_Animator.SetBool("Clicked", true);

        Button_1_Test.Instance.SongButtons();
    }
}
