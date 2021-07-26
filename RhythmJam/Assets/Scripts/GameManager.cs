using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Current Screen")]
    public bool m_StartScreen;
    public bool m_TrackSelection;
    public bool m_OptionsMenu;
    public bool m_InGame;
    public bool m_Pause;

    [Header("Pause")]
    [SerializeField] private GameObject m_PauseMenu = null;

    [Header("Game Over")]
    [SerializeField] private GameObject m_GameOverMenu = null;

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<GameManager>();
                    singleton.name = "(Singleton) GameManager";
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        m_StartScreen = true;
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (m_InGame && !m_Pause)
            {
                Pause();
            }
            else if (m_Pause)
            {
                Resume();
            }
            else if (!m_InGame && !m_StartScreen)
            {
                Start_Screen.Instance.BackIsClicked();
            }
        }
        */
    }

    public void LoadScene(string SceneToLoad)
    {
        m_TrackSelection = false;
        m_InGame = true;
        SceneManager.LoadScene(SceneToLoad);
    }

    /*
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        m_PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        m_Pause = false;

        Debug.Log("RESUME");
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        m_PauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        m_Pause = true;

        Debug.Log("PAUSE");
    }

    public void Restart()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Debug.Log("PLAY AGAIN");
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        m_GameOverMenu.SetActive(true);
    }
    */

    public void Quit()
    {
        Application.Quit();
    }
}
