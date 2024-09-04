using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public float damage = 0f;
    public float explosionRadius = 0f;
    private float rotateSpeed = 2000f;

    private Rigidbody2D bulletRB;
    // Update is called once per frame

    private void Awake()
    {
        bulletRB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {   //destroy this bullet if the target is dead
        if (target.GetComponent<Enemy>().health <= 0 || target.GetComponent<Enemy>().isAlive == false)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
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

    private void FixedUpdate()
    {
        Vector2 dir = (Vector2)target.position - bulletRB.position;
        dir.Normalize();
        float rotateAmount = Vector3.Cross(dir, transform.right).z;
        bulletRB.angularVelocity = -rotateAmount * rotateSpeed;
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
        Enemy enemy = _enemy.GetComponent<Enemy>(); // lấy code của thằng mục tiêu
        if (enemy.health >= 1) // nếu mà máu mục tiêu > 0
        {
            enemy.health -= damage; // trừ máu
            enemy.healthBar.UpdateHealth(enemy.health, enemy.maxHealth); //cập nhật thanh máu
            if(enemy.health <= 0) //nếu máu < 0
            {
                enemy.Die(); //địch chết
            }
        }
    }

    IEnumerator Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, LayerMask.GetMask("Enemy"));
        foreach (Collider2D collider in colliders)
        {
            Damage(collider.transform);
        }
        yield return new WaitForSeconds(0);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    IEnumerator Turning()
    {
        yield return new WaitForSeconds(0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Hit enemy");
        }
    }
}
