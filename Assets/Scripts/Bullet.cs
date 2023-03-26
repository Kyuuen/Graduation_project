using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public float damage = 0f;
    public float explosionRadius = 0f;
    // Update is called once per frame
    void Update()
    {   //destroy this bullet if target disappear
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        //calculate the distance between this bullet
        //and the target this frame
        Vector2 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        //check if this bullet hit the target yet or not
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            FindObjectOfType<AudioManager>().Play("Hit");
            return;
        }
        //translate it to target
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    public void HitTarget()
    {
        if(explosionRadius > 0f)
        {
            StartCoroutine(Explode());
        }
        else
        {
            Damage(target);
        }
        //Destroy the bullet after hit the target
        Destroy(gameObject);
    }

    void Damage(Transform _enemy)
    {
        Enemy enemy = _enemy.GetComponent<Enemy>();
        if (enemy.health >= 1)
        {
            enemy.health -= damage;
            Debug.Log("Enemy health " + enemy.health);
            if(enemy.health <= 0)
            {
                enemy.Die();
            }
        }
    }

    IEnumerator Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius, LayerMask.GetMask("Enemy"));
        foreach (Collider collider in colliders)
        {
            Damage(collider.transform);
            Debug.Log("Hit " + collider.tag);
        }
        yield return new WaitForSeconds(0);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            Debug.Log("Hit enemy");
        }
    }
}
