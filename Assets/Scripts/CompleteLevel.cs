using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string nextLevel = "Lv2";
    public int levelToUnlock = 2;

    public SceneFader sceneFader;
    public void Menu()
    {
        sceneFader.FadeTo("Menu");
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);   
    }
}
