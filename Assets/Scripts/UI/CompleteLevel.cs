using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string nextLevel;
    public int levelToUnlock;
    public static bool gameIsPlayed = false;

    public SceneFader sceneFader;

    private void Awake()
    {
        gameIsPlayed = true;
    }
    public void Menu()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo("Menu");
    }

    public void Continue()
    {
        //gameIsPlayed = true;
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
        FindObjectOfType<AudioManager>().Play("Theme");
    }
}
