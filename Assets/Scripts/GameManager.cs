using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;
    public GameObject gameOverUI;

    public string nextLevel = "Lv2";
    public int levelToUnlock = 2;

    public SceneFader sceneFader;

    public GameObject completeLevelUI;

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
    }
    public void Winlevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);   
    }
}
