using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool isGamePaused = false;
    public GameObject menuPanel;
    public TextMeshProUGUI health;
    public Player player;

    void Update()
    {
        health.text = player.health.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0f;
        menuPanel.SetActive(true);
    }

    public void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1f;
        menuPanel.SetActive(false);
    }
}

