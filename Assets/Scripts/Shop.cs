using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public TowerBluePrint archerTower;
    public TowerBluePrint wizardTower;
    public TowerBluePrint catapultTower;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectArcherTower()
    {
        Debug.Log("archer tower selected");
        buildManager.SelectTowerToBuild(archerTower);
    }
    public void SelectWizardTower()
    {
        Debug.Log("wizard tower selected");
        buildManager.SelectTowerToBuild(wizardTower);
    }

    public void SelectCatapultTower()
    {
        Debug.Log("catapult tower selected");
        buildManager.SelectTowerToBuild(catapultTower);
    }
}
