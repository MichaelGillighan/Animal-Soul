using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreBullets : MonoBehaviour {

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("Sizarras");
            //Physics2D.IgnoreCollision(other.collider, collider);
            //Physics.IgnoreCollision(other.collider, collider);
            Physics2D.IgnoreCollision(other.collider, GetComponent<BoxCollider2D>());
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
