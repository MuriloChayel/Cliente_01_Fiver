using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject StartCanvas;
    public GameObject pontuation;
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text best;
    Scene currentScene;

    private void Start()
    {
        Time.timeScale = 0;
        currentScene = SceneManager.GetActiveScene();
    }
    public void StartGame()
    {
        StartCanvas.SetActive(false);
        pontuation.SetActive(true);
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
    }
    public void RestartLevel(string newScore)
    {
        score.text = newScore;
        gameOverCanvas.SetActive(false);
    }
    public void Reset()
    {
        ResetScore();
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
    public void ResetScore()
    {
        score.text = "0";
    }
}
