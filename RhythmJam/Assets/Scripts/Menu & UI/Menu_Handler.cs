using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Handler : MonoBehaviour
{
    private static Menu_Handler instance;

    public static Menu_Handler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Menu_Handler>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject();
                    singleton.AddComponent<Menu_Handler>();
                    singleton.name = "(Singleton) Menu_Handler";
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    [Header("Start Menu")]
    [SerializeField] private GameObject m_StartMenu = null;

    [Header("Pause")]
    [SerializeField] private GameObject m_PauseMenu = null;
    [SerializeField] public static bool m_Paused;

    [Header("Game Over")]
    [SerializeField] private GameObject m_GameOverMenu = null;

    [Header("You Win")]
    [SerializeField] private GameObject m_YouWinMenu = null;

    void Start()
    {
        StartMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (m_Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        m_StartMenu.SetActive(false);
        m_PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        m_Paused = false;

        Debug.Log("PLAY");
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        m_PauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        m_Paused = true;

        Debug.Log("PAUSE");
    }

    public void Restart()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Debug.Log("PLAY AGAIN");
    }

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void YouWin()
    {
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        m_YouWinMenu.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        m_GameOverMenu.SetActive(true);
    }

    public void StartMenu()
    {
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        m_StartMenu.SetActive(true);
        m_Paused = true;

        Debug.Log("START");
    }
}
