using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    
    //private Animator animator;
    private SpriteRenderer sR;
    private Rigidbody2D rB;
    private Transform myTrans;
    private bool dentroRango=false;
    public Transform target;
    public int health=3;
    public float speed=1;

    void Start ()
    {
        //animator=GetComponent<Animator>();
        sR = GetComponent<SpriteRenderer>();
        rB = GetComponent<Rigidbody2D>();
        myTrans = GetComponent<Transform>();
	}
	
	void Update () {
		
	}

    void FixedUpdate()
    {
        Movimiento(dentroRango);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            dentroRango = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            dentroRango = false;
        }
    }

    public void Movimiento(bool dentroRango)
    {
        if (dentroRango)
        {
            //Debug.Log("es como careachimba");
            if (myTrans.transform.position.x > target.transform.position.x)
            {
                rB.velocity = new Vector2(-speed, rB.velocity.y);
                sR.flipX = true;
            }
            if (target.transform.position.x > myTrans.transform.position.x)
            {
                rB.velocity = new Vector2(speed, rB.velocity.y);
                sR.flipX = false;
            }
        }
        
    }
}

