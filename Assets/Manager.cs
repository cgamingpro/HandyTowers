using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    

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


    public void ResetCoins()
    {
        coinCount = 0;
        Debug.Log("Coins reset.");
    }
}
