using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject ui;
    public Text upgradeCost;
    public Text sellAmount;
    public Button upgradeButton;
    private int diff;

    public void SetTarget(Node target)
    {

        this.target = target;
        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded)
        {
            // if (PlayerStats.Money < target.turretBlueprint.upgradeCost)
            // {
            //     upgradeButton.interactable = false;
            // }
            
            
                upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
                upgradeButton.interactable = true;
            
        }
        else
        {
            
            upgradeCost.text = "Done";

            upgradeButton.interactable = false;
        }
        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }

}
