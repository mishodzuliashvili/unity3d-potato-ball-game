using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_gameOverText;
    [SerializeField] TextMeshProUGUI m_timerText;
    [SerializeField] Score m_payerScore;
    [SerializeField] Score m_enemyScore;

    [SerializeField] float m_gameTimeInSeconds = 60f;
    float m_timer;
    bool m_gameIsPlaying = false;
    public static float RespawnHeight = 0.25f;

    void Start()
    {
        Time.timeScale = 0f;
        m_timer = m_gameTimeInSeconds;
        UpdateTimer();
    }

    void FixedUpdate()
    {
        if (!m_gameIsPlaying) return;

        m_timer -= Time.deltaTime;

        if (m_timer <= 0f)
        {
            GameOver();
            m_timer = 0f;
        }

        UpdateTimer();
    }
    void GameOver()
    {
        m_gameIsPlaying = false;
        Time.timeScale = 0f;

        string gameOverText;
        if (m_payerScore.ScoreValue > m_enemyScore.ScoreValue)
        {
            gameOverText = "YOU WIN!";
        }
        else if (m_payerScore.ScoreValue < m_enemyScore.ScoreValue)
        {
            gameOverText = "YOU LOSE!";
        }
        else
        {
            gameOverText = "TIE!";
        }

        m_gameOverText.text = gameOverText + "\nPress Space to Restart!";

        m_gameOverText.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        if (!m_gameIsPlaying)
        {
            m_gameIsPlaying = true;
            Time.timeScale = 1f;

            m_gameOverText.gameObject.SetActive(false);

            m_timer = m_gameTimeInSeconds;
            UpdateTimer();
        }
    }
    void UpdateTimer()
    {
        m_timerText.text = string.Format("{0:0}:{1:00}", Mathf.Floor(m_timer / 60), Mathf.Floor(m_timer % 60));
    }
}
