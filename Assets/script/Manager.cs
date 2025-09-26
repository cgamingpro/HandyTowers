using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public int nextUpgradeCost;


    [SerializeField] ToweUpgrade toweUpgrade;
    [SerializeField] GameObject upgradeMesh;
    Material updatedMaterail;
    GameObject goal;
    public int goalhealt;
    GoalDamage goalDamage;
    public int coinCount = 0;

    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }
    private void Start()
    {
        goal = GameObject.Find("Goal");
        goalDamage = goal.GetComponent<GoalDamage>();
        updatedMaterail = upgradeMesh.GetComponent<Renderer>().material;
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        Debug.Log("Coins: " + coinCount);
    }


    public bool SpendCoins(int amount)
    {
        if (coinCount >= amount)
        {
            coinCount -= amount;
            Debug.Log("Coins left: " + coinCount);
            return true;
        }
        else
        {
            Debug.Log("Not enough coins!");
            return false;
        }
    }

    private void Update()
    {
        goalhealt = goalDamage.health;
        nextUpgradeCost =  (toweUpgrade.towerLvl + 1) * 100;


        if (nextUpgradeCost <= coinCount)
        {
            Color col = updatedMaterail.GetColor("_TintColor");
            col.a = 0.5f; // 50% transparent
            updatedMaterail.SetColor("_TintColor", col);

        }
        else
        {
            Color col = updatedMaterail.GetColor("_TintColor");
            col.a = 0f; // fully invisible
            updatedMaterail.SetColor("_TintColor", col);
        }
       

    }

    public void ResetCoins()
    {
        coinCount = 0;
        Debug.Log("Coins reset.");
    }
}
