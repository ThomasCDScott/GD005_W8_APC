using UnityEngine;
using System;
using System.Collections.Generic;

public class HighScoreHandler : MonoBehaviour
{
    private int m_Points;
    int m_Highscore;
    [SerializeField] HighScoreUI highscoreUI;

    public int Highscore
    {
        set
        {
            Highscore = value;
            highscoreUI.SetHighscore(value);
        }
    }
    private void Start()
    {
        SetLatestHighScore();
    }

    private void SetLatestHighScore()
    {
        m_Highscore = PlayerPrefs.GetInt("Highscore", 0);
    }

    private void SaveHighscore(int m_Points)
    {
        PlayerPrefs.SetInt("Highscore", m_Points);
    }

    public void SetHighscoreIfGreater(int m_Points)
    {
        if (m_Points < m_Highscore)
        {
            m_Highscore = m_Points;
            SaveHighscore(m_Points);
        }
    }

}
