using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Asteroids.Scripts.Controller;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Asteroids.Scripts.Controller
{
    public class UIController : Shared.Controller<UIController>
    {
        public GameObject gameOverPanel;
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI highScoreText;
        public List<Image> healthImages;

        void Start()
        {
            SetGameOverVisibility(false);
        }
        
        public void UpdateScore(int score)
        {
            scoreText.text = (Convert.ToInt32(scoreText.text) + score).ToString();
        }

        public void UpdateLifes(int lifesRemaining)
        {
            healthImages[lifesRemaining - 1].enabled = false;
        }

        public void UpdateHighScore()
        {
            int highScore = PlayerPrefs.GetInt("HighScore");
            int newScore = Convert.ToInt32(scoreText.text);
            if (highScore < newScore)
            {
                highScore = newScore;
                PlayerPrefs.SetInt("HighScore", highScore);
            }
            highScoreText.text = highScore.ToString();
        }

        public void SetGameOverVisibility(bool active)
        {
            gameOverPanel.SetActive(active);
        }

        public void ResetUI()
        {
            scoreText.text = "0";
            foreach (Image lifeImage in healthImages)
            {
                lifeImage.enabled = true;
            }
            SetGameOverVisibility(false);
        }
    }
}