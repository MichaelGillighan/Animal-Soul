using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public float timer;

    void Start()
    {
       rb.velocity = transform.right * speed;
    }

    private void Update()
    {     
        timer += 1.0F * Time.deltaTime;
        if (timer >= 4)
        {
            GameObject.Destroy(gameObject);
        }
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyFollow>().TakeDamage();
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Boss")
        {
            other.gameObject.GetComponent<DisparosHand>().TakeDamage();
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "masterHand")
        {
            Destroy(gameObject);
        }
    }
}
