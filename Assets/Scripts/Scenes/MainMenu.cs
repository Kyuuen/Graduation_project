using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;
    
    public void Information()
    {
        sceneFader.FadeTo("Information");
    }

    public void Play()
    {
        sceneFader.FadeTo("Level Select");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
