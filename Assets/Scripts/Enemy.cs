using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int value;
    public float speed = 10f;
    public float health;

    private Transform target;
    public int wavepointIndex = 0;
    public Animator animator;

    void Start()
    {
        target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {   //Move the Enemy to the next waypoint
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
    }

    void GetNextWaypoint()
    {   //Enemy find the position of the next waypoint
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {       
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
