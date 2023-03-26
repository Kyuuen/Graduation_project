using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private TowerBluePrint towerToBuild;
    public GameObject archerTowerPrefab;
    public GameObject wizardTowerPrefab;
    public GameObject catapultTowerPrefab;

    public GameObject buildEffect;
    private Node selectedNode;
    public NodeUI nodeUI;

    private void Awake()
    {   
        if( instance != null)
        {
            Debug.LogError("There are more than 1 build manager");
            return;
        }
        instance = this;
    }
    
    public bool CanBuild{ get { return towerToBuild != null; }}

    public void SelectNode(Node node)
    {   
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        towerToBuild = null;

        nodeUI.SetTarget(node);       
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTowerToBuild(TowerBluePrint tower)
    {
        towerToBuild = tower;
        DeselectNode();
    }

    public TowerBluePrint GetTowerToBuild()
    {
        return towerToBuild;
    }
}
