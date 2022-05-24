using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrito : MonoBehaviour {

    public int speed = 5;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Player 2")
        {
            StartCoroutine(Mover());
        }
    }

    IEnumerator Mover()
    {
        rb.velocity += speed * Vector2.right;
        yield return new WaitForSeconds(5);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(1);
        rb.velocity += speed * Vector2.left;
        yield return new WaitForSeconds(5);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(1);
        StartCoroutine(Mover());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Player 2")
        {
            StopAllCoroutines();
            rb.velocity = Vector2.zero;
        }
    }

}
