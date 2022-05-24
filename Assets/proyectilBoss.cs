using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectilBoss : MonoBehaviour {

    //public float speed = 10f;
    private float speed2;
    private Rigidbody2D rb;
    public int tiempoDespawn = 3;
    public float min = 0.19f;
    public float max = 0.3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        speed2 = Random.Range(5, 20);

        rb.velocity = -transform.right * speed2;

        float r = Random.Range(min, max);

        gameObject.transform.localScale = new Vector3(r,r,r);

        StartCoroutine(Despawn());
    }

    void Update()
    {
        Physics2D.IgnoreLayerCollision(14, 13);
        Physics2D.IgnoreLayerCollision(14, 0);
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(tiempoDespawn);
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player 2")
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage();
            Destroy(gameObject);
        }
    }

}
