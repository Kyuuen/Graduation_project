using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{   
    [Header("Attributes")]
    public float range = 10f;
    public float fireRate = 1f;
    private float fireCountDown = 0f;
    [Header("Unity Setup fields")]
    public string enemyTag = "Enemy";
    public Transform target;
    public GameObject bulletPrefabs;
    public Transform firePoint;
    //public Transform partToRotate;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
    }

    void UpdateTarget()
    {   
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        //Find the nearest enemy
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        //Lock on to the nearest enemy
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        //Stop tracking if the enemy is out of range
        if (shortestDistance > range)
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        if (target.GetComponent<Enemy>().health <= 0)
        {
            target = null;
            return;
        }
        else
        {
            if (fireCountDown <= 0f)
            {
                Shoot();
                fireCountDown = 1f / fireRate;
            }
        }

        fireCountDown -= Time.deltaTime;
        //Vector3 dir = target.position - transform.position;
        //Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Vector3 rotation = lookRotation.eulerAngles;
        //partToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y , rotation.z);
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefabs, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();
        if(bullet != null)
        {
            bullet.Seek(target);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
