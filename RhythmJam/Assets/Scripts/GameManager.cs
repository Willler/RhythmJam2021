using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Current Screen")]
    [SerializeField] private bool m_StartScreen;
    [SerializeField] private bool m_TrackSelection;
    [SerializeField] private bool m_OptionsMenu;
    [SerializeField] private bool m_InGame;
    [SerializeField] private bool m_PauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && m_InGame && !m_PauseMenu)
        {
            Menu_Handler.Instance.Pause();
            m_PauseMenu = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && m_InGame && m_PauseMenu)
        {
            Menu_Handler.Instance.Resume();
            m_PauseMenu = false;
        }
    }

    public void LoadScene(string SceneToLoad)
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
