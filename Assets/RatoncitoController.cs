using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatoncitoController : MonoBehaviour {

    private Transform target;
    public float enemyDistance;
    public float speed = 5;
    public int timeExploit = 5;
    public GameObject explocion;

    

    void Start () {

        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            target = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Transform>();
        }
        if (GameObject.FindGameObjectWithTag("Boss") != null)
        {
            target = GameObject.FindGameObjectWithTag("Boss").GetComponent<Transform>();
        }

        if (target == null)
        {
            StartCoroutine(Explotar());
        }
    }

    public IEnumerator Explotar()
    {
        yield return new WaitForSeconds(timeExploit);

        Instantiate(explocion, transform.position, transform.rotation);

        Destroy(gameObject);
    }	

	void Update ()
    {
        Physics2D.IgnoreLayerCollision(12, 8);
        Physics2D.IgnoreLayerCollision(12, 9);
        Physics2D.IgnoreLayerCollision(12, 10);
        Physics2D.IgnoreLayerCollision(12, 11);
        Physics2D.IgnoreLayerCollision(12, 13);
        Physics2D.IgnoreLayerCollision(12, 14);
        

        if (target != null)
        {
            
            if (Vector2.Distance(transform.position, target.position) < enemyDistance)
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);

        }
        
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyFollow>().TakeDamageMouse();

            Instantiate(explocion, transform.position, transform.rotation);

            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Boss")
        {
            other.gameObject.GetComponent<DisparosHand>().TakeDamage2();

            Instantiate(explocion, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
