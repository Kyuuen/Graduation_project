using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject ui;
    public Text sellAmount;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.transform.position;
        ui.SetActive(true);

        sellAmount.text = "Sell for $" + target.towerBluePrint.GetSellAmount();
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Sell()
    {   
        target.SellTower();
        BuildManager.instance.DeselectNode();
    }
}
