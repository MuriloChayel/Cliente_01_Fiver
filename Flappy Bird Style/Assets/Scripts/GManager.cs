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
    public GameObject spawnPoint;
    public GameObject startButton;
    public GameObject PlayeButton;
    //TUTORIA--
    public GameObject tutorial;
    public Animator tutorialAn;
    //---

    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text best;
    Scene currentScene;

    [SerializeField] Rigidbody2D playerRb;
    public PlayerBehaviour pb;

    bool pause;
    
    private void Start()
    {
        //Time.timeScale = 0;
        currentScene = SceneManager.GetActiveScene();
    }
    int a = 0;
    public void StartGame()
    {
        if (a == 0)
        {
            pb.Flap();
            a++;    
        }
        tutorialAn.Play("fade");
        spawnPoint.SetActive(true);
        PlayeButton.SetActive(false);
        pb.inGame = true;
        Time.timeScale = 1;
        playerRb.bodyType = RigidbodyType2D.Dynamic;
        StartCanvas.SetActive(false);
        pontuation.SetActive(true);
        spawnPoint.SetActive(true);
        //Time.timeScale = 1;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        playerRb.bodyType = RigidbodyType2D.Kinematic;

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
    public void PauseGame()
    {
        pause = !pause;
        if (pause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    public void Tutorial()
    {
     
        startButton.SetActive(false);
        tutorial.SetActive(true);
    }
}
