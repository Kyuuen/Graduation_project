using UnityEngine;

public class Node : MonoBehaviour
{   [HideInInspector]
    public GameObject tower;
    BuildManager buildManager;
    [HideInInspector]
    public TowerBluePrint towerBluePrint;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    void OnMouseDown()
    {      
        if (tower != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild) return;

        if (Input.GetMouseButtonDown(0))
        {
            BuildTower(buildManager.GetTowerToBuild());
        }
        
    }

    void BuildTower(TowerBluePrint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("you're too poor");
            return;
        }
        towerBluePrint = blueprint;
        PlayerStats.Money -= blueprint.cost;
        GameObject _tower = (GameObject)Instantiate(blueprint.prefab, transform.position, Quaternion.identity);
        tower = _tower;
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        FindObjectOfType<AudioManager>().Play("Towerbuild");
    }
    public void SellTower()
    {
        PlayerStats.Money += towerBluePrint.GetSellAmount();

        Destroy(tower);
        towerBluePrint = null;
    }
    private void OnMouseEnter()
    {
        if (!buildManager.CanBuild ) return;
    }
}
