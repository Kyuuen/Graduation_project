using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayInfo : MonoBehaviour
{
    int pageIndex;
    public Button toFrontBtn, toBackBtn;
    public GameObject[] pages;
    GameObject selectedPage;

    private void Awake()
    {
        pageIndex = 0;
        selectedPage = pages[0];
    }
    private void Update()
    {
        if (pageIndex > 0)  toFrontBtn.interactable = true;
        else toFrontBtn.interactable = false; 
        if (pageIndex < 3) toBackBtn.interactable = true;
        else toBackBtn.interactable = false;
    }

    public void toFront()
    {
        selectedPage.SetActive(false);
        pageIndex--;
        selectedPage = pages[pageIndex];
        selectedPage.SetActive(true);
    }

    public void toBack()
    {
        selectedPage.SetActive(false);
        pageIndex++;
        selectedPage = pages[pageIndex];
        selectedPage.SetActive(true);
    }
}
