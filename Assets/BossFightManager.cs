using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightManager : MonoBehaviour {

    public GameObject boss;
    public GameObject camera1;
    public GameObject camera2;
    public Animator transicion;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Player 2")
        {
            transicion.SetTrigger("paneo");
            camera1.SetActive(false);
            camera2.SetActive(true);
            boss.SetActive(true);            
        }        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player 2").transform.position = other.gameObject.transform.position;
            GetComponent<BoxCollider2D>().isTrigger = false;
        }

        if (other.gameObject.tag == "Player 2")
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = other.gameObject.transform.position;
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
