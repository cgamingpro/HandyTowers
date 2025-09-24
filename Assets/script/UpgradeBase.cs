using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBase : MonoBehaviour
{
    public int upgradeCost;   
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Tower"))
        {
            ToweUpgrade toweUpgrade = other.GetComponent<ToweUpgrade>();
            int aviablabeCoin = Manager.Instance.coinCount;
            upgradeCost = (toweUpgrade.towerLvl + 1) * 100;

            if(upgradeCost <= aviablabeCoin && toweUpgrade.towerLvl < toweUpgrade.towerStates.Count -1)
            {
                toweUpgrade.UpgradeTheMesh();
                Manager.Instance.SpendCoins(upgradeCost);
            }
            else
            {
                Debug.Log("not enough coins here");
            }
        }
    }
}
