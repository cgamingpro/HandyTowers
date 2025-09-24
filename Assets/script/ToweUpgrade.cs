using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToweUpgrade : MonoBehaviour
{
    public List<GameObject> towerStates = new List<GameObject>();
    [SerializeField] Transform stateParetnObj;
    public int towerLvl = 0;
    
    void Start()
    {
        InstTowers();
    }
    void InstTowers()
    {
        foreach (Transform t in stateParetnObj)
        {
            towerStates.Add(t.gameObject);
        }
        foreach(GameObject g in towerStates)
        {
            g.SetActive(false);
        }
        towerStates[towerLvl].SetActive(true);
        ApplyStat();
    }
    public void UpgradeTheMesh()
    {
        towerLvl++;
        foreach (GameObject g in towerStates)
        {
            g.SetActive(false);
        }
        towerStates[towerLvl].SetActive(true);
        ApplyStat();
    }

    void ApplyStat()
    {
        StatsPerTower statsPerTower = towerStates[towerLvl].gameObject.GetComponent<StatsPerTower>();
        Tower tower = gameObject.GetComponent<Tower>();
        tower.firePoint = statsPerTower.nfirePoint;
        tower.fireRate = statsPerTower.nfireRate;
        tower.currenWeapon = statsPerTower.nweapon;
        tower.bulletVelocity = statsPerTower.nbulletVelocity;
        tower.BulletPreab = statsPerTower.nBulletPreab;
    }
    void Update()
    {
        
    }
}
