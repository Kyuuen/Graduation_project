using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public GameObject gameOverUI;

    public string nextLevel;
    public int levelToUnlock;

    public SceneFader sceneFader;

    public GameObject completeLevelUI;
    public static bool stopTheme = false;

    private void Start()
    {
        GameIsOver = false;
    }
    private void Update()
    {
        if (GameIsOver) return;
        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
        FindObjectOfType<AudioManager>().Stop("Theme");
        FindObjectOfType<AudioManager>().Stop("BossFight");
        FindObjectOfType<AudioManager>().Play("LevelLosing");
    }
    public void Winlevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
        FindObjectOfType<AudioManager>().Stop("Theme");
        FindObjectOfType<AudioManager>().Stop("BossFight");
        FindObjectOfType<AudioManager>().Play("Victory");
    }
}
