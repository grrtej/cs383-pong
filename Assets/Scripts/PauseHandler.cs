using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    GameObject pausePanel;
    bool isPaused = false;

    void Start()
    {
        pausePanel = GameObject.Find("Pause Panel");
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (isPaused)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = false;
                pausePanel.SetActive(false);
                Time.timeScale = 1.0f;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = true;
                pausePanel.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
    }
}
