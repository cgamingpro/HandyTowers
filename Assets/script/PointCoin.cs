using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCoin : MonoBehaviour
{
    public int value = 10;
    [SerializeField] AudioClip pickupclip;
    AudioSource pickupsource;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            TowerPickup towerPickup = other.GetComponent<TowerPickup>();
            if(!towerPickup.isHoldingT)
            {
                Manager.Instance.AddCoins(value);
                pickupsource = Manager.Instance.GetComponent<AudioSource>();
                pickupsource.PlayOneShot(pickupclip);
                Destroy(gameObject);
            }
            
        }
    }
}
