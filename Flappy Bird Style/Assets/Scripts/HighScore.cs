using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TMP_Text bestScore;

    private void Start()
    {
        bestScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    public void SetHighScore(int highScore)
    {
        if (highScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", highScore);
            bestScore.text = highScore.ToString();
        }
    }

}
