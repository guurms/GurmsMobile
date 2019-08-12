using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float time = 0;

    public static bool playerAlive;

    public TextMeshProUGUI score;

    public GameObject gameOverUI;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        time = 0;
        Time.timeScale = 1f;
        playerAlive = true;
    }

    void Update()
    {
        if(playerAlive)
        {
            time += Time.deltaTime;
            score.text = ((int)time).ToString();
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        playerAlive = false;
        gameOverUI.SetActive(true);
    }
}
