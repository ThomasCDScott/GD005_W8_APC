using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
public class HighScoreUI : MonoBehaviour
{
    [SerializeField] Text highscoreText;

    public void SetHighscore(int m_Points)
    {
        highscoreText.text = m_Points.ToString();
    }
}
