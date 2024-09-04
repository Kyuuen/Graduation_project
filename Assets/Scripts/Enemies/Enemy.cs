using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int value;
    public float speed = 10f;
    public float health;
    [HideInInspector] public float maxHealth;
    public int waypointSetIndex;
    public int damageToPlayer;

    public Transform target;
    public int wavepointIndex = 0;
    public Animator animator;
    public bool isBoss = false;
    public bool isAlive;

    public HealthBar healthBar;
    void Start()
    {
        maxHealth = health;
        isAlive = true;
        if (waypointSetIndex == 1)
        {
            target = Waypoints.points1[0];
        }
        else if (waypointSetIndex == 2)
        {
            target = Waypoints.points2[0];
        }

        healthBar.GetMaxHealth();
    }
        
    // Update is called once per frame
    void Update()
    {   //Move the Enemy to the next waypoint
        if (speed == 0) return;
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
        //Change the animator's parameter
        animator.SetFloat("Speed", speed);
    }

    public void Die()
    {
        animator.SetBool("Dead", true);
        speed = 0f;
        WaveSpawner.EnemiesAlive--;
        PlayerStats.Money += value;
        Destroy(gameObject, 1f);
        FindObjectOfType<AudioManager>().Play("EnemyDeath");
        if (isBoss)
        {
            WaveSpawner.bossAlive = false;
        }
    }

    void GetNextWaypoint()
    {   //Enemy find the position of the next waypoint
        if (wavepointIndex >= Waypoints.GetWaypointCount(waypointSetIndex) - 1)
        {
            isAlive = false;
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.GetWaypoint(wavepointIndex, waypointSetIndex);
    }

    public void SetWaypointSetIndex(int _waypointSetIndex)
    {
        waypointSetIndex = _waypointSetIndex;
    }

    void EndPath()
    {       
        PlayerStats.Lives -= damageToPlayer;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
