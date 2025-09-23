using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOBJ : MonoBehaviour
{
    public int damge = 45;
    Rigidbody rb;
    [SerializeField] AudioClip hitSOund;

    [SerializeField] GameObject hitParticalefect;
    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
       

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("atleast the check is working");

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy: " + other.name);
            other.GetComponent<EnemyHealth>().applyDamage(damge);
            if (other.GetComponent<Rigidbody>() != null)
            {
                other.GetComponent<Rigidbody>().AddForce(rb.velocity.normalized * 2, ForceMode.Impulse);

                Debug.Log("force aded");
            }
            Instantiate(hitParticalefect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }


      
    }
}
