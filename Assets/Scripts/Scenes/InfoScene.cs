using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoScene : MonoBehaviour
{
    public GameObject allStack;
    public GameObject gamePlayStack;
    public GameObject towerStack;
    public GameObject enemiesStack;
    public SceneFader sceneFader;
    public GameObject backBtn;
    public Text title;

    GameObject selectedStack;
    public void GamePlay()
    {
        backBtn.SetActive(true);
        title.text = "GamePlay";
        allStack.SetActive(false);
        gamePlayStack.SetActive(true);
        selectedStack = gamePlayStack;
    }

    public void Back()
    {
        backBtn.SetActive(false);
        title.text = "Information";
        allStack.SetActive(true);
        selectedStack.SetActive(false);
    }
    public void Return()
    {
        sceneFader.FadeTo("Menu");
    }
    public void Tower()
    {
        backBtn.SetActive(true);
        title.text = "Tower";
        towerStack.SetActive(true);
        allStack.SetActive(false);
        selectedStack = towerStack;
    }

    public void Enemies()
    {
        backBtn.SetActive(true);
        title.text = "Enemies";
        allStack.SetActive(false);
        enemiesStack.SetActive(true);
        selectedStack = enemiesStack;
    }

    
}
