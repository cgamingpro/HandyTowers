using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    GameObject[] Enemys;
    //all public so later it can be setted with the level system of the towers
    public GameObject currenWeapon;
    public float range;
    public Transform firePoint;
    public float fireRate;
    public GameObject BulletPreab;
    public float bulletVelocity;
    float fireCooolDown;

    GameObject curretnTarget = null;
     
    private void Update()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDist = range * range;
        foreach (GameObject enemy in Enemys)
        {
            float dist = Vector3.Distance(enemy.transform.position,transform.position);
            if(dist < shortestDist && dist < range)
            {
                shortestDist = dist;
                curretnTarget = enemy;
            }
        }


        if (curretnTarget != null && Vector3.Distance(transform.position, curretnTarget.transform.position) < range)
        {
            Vector3 dir = curretnTarget.transform.position - currenWeapon.transform.position;
            dir.y = 0;
            Quaternion lookRot = Quaternion.LookRotation(dir,Vector3.up);
            currenWeapon.transform.rotation = Quaternion.RotateTowards(currenWeapon.transform.rotation, lookRot, Time.deltaTime * 500);
        }




        if(fireCooolDown <= 0 && curretnTarget != null && Vector3.Distance(transform.position,curretnTarget.transform.position) < range)
        {
            fireCooolDown = 1 / fireRate;
            Shoot();
        }
        fireCooolDown -= Time.deltaTime;
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(BulletPreab,firePoint.position,firePoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(firePoint.forward * bulletVelocity, ForceMode.Impulse);

    }

}
