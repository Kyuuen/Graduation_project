using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;

    private void Awake()
    {
        CameraResizer(Camera.main);
    }

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
