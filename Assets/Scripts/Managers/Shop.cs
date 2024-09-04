using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public TowerBluePrint archerTower;
    public TowerBluePrint wizardTower;
    public TowerBluePrint catapultTower;

    public GameObject selectTowerUI;
    public Text selectTowerText;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectArcherTower()
    {
        StartCoroutine(SelectTowerUI("Archer Tower"));
        buildManager.SelectTowerToBuild(archerTower);
    }
    public void SelectWizardTower()
    {
        StartCoroutine(SelectTowerUI("Wizard Tower"));
        buildManager.SelectTowerToBuild(wizardTower);
    }

    public void SelectCatapultTower()
    {
        StartCoroutine(SelectTowerUI("Catapult Tower"));
        buildManager.SelectTowerToBuild(catapultTower);
    }

    IEnumerator SelectTowerUI(string towerName)
    {
        selectTowerText.text = towerName + " selected!";
        selectTowerUI.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        selectTowerUI.SetActive(false);
    }
}
