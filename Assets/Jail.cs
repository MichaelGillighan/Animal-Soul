using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jail : MonoBehaviour {

    private Animator anim;
    private SpriteRenderer mySprite;
    public GameObject gm;
    //public GameObject[] picks;
    

	// Use this for initialization
	void Start () {
        mySprite = GetComponent<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RescueAnim()
    {
        mySprite.enabled = false;
        anim.SetBool("Open",true);
        //Destroy(gameObject);
        StartCoroutine(Espera());
        //Instantiate((gm.GetComponent<GameManager>().PickUps[0]), transform.position, transform.rotation);
    }

    IEnumerator Espera()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
        
        gm.GetComponent<GameManager>().Instanciar(transform);
    }
}
