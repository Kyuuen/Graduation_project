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

    private void Awake()
    {
        CameraResizer(Camera.main);
    }

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

    public void CameraResizer(Camera camera)
    {
        float baseWidth = 1920f;
        float baseHeight = 1080f;

        // Calculate the base aspect ratio
        float baseAspectRatio = baseWidth / baseHeight;

        // Calculate the current aspect ratio
        float currentAspectRatio = (float)Screen.width / Screen.height;
        // Calculate the scaling factor to maintain the aspect ratio
        float scale = baseAspectRatio / currentAspectRatio;
        // Adjust the camera's orthographic size based on the scaling factor
        camera.orthographicSize = camera.orthographicSize * scale;
        // Divide by 200 because orthographicSize represents half the height in world units.
    }
}
