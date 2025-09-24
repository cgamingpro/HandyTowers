using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDamage : MonoBehaviour
{
    public int health = 100;
   

    [SerializeField] AudioClip audioClip;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void applyDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            GameOver();
        }
        audioSource.PlayOneShot(audioClip);

    }

    void GameOver()
    {
        Debug.Log("Game ended my boy");
    }
}
