using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;
    public int damageToGoal = 10;
    public float damageInterval = 1f;

    private float damageTimer = 0f;
    private bool inGoal = false;
    private GoalDamage goalRef;

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
        }
        audioSource.PlayOneShot(audioClip);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            goalRef = other.GetComponent<GoalDamage>();
            inGoal = true;
            damageTimer = 0f; // reset timer so damage applies immediately
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (inGoal && goalRef != null)
        {
            damageTimer -= Time.deltaTime;
            if (damageTimer <= 0f)
            {
                goalRef.applyDamage(damageToGoal);
                Debug.Log("aply dagme was pased");
                damageTimer = damageInterval; // reset
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Goal"))
        {
            inGoal = false;
            goalRef = null;
        }
    }
}
