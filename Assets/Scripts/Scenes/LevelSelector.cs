using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButtons;

    public int levelReached = 1;

    private void Awake()
    {
        CameraResizer(Camera.main);
    }

    private void Start()
    {
        if(CompleteLevel.gameIsPlayed) levelReached = PlayerPrefs.GetInt("levelReached", 1);
        //Debug.Log("opening level: " + levelReached);
        for(int i=0; i< levelButtons.Length; i++)
        {   
            if(i + 1 > levelReached)
                levelButtons[i].interactable = false;
        }
    }
    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }

    public void Return()
    {
        fader.FadeTo("Menu");
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
