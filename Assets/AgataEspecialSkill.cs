using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgataEspecialSkill : MonoBehaviour {

    public KeyCode specialAtk;
    public int cooldown = 5;
    private bool readyAtk = true;
    public GameObject ratoncito;

    public Animator specialSkill;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        specialSkill.SetBool("readyAtk", readyAtk);
	}

    void FixedUpdate()
    {
        if (Input.GetKeyDown(specialAtk) && readyAtk)
        {
            TirarRatoncito();
        }
    }

    public void TirarRatoncito()
    {
        StartCoroutine(DropMouse());
        //StartCoroutine();
    }

    IEnumerator DropMouse()
    {
        readyAtk = false;
        Instantiate(ratoncito, transform.position, transform.rotation);
        //StartCoroutine(ratoncito.GetComponent<RatoncitoController>().Explotar());
        yield return new WaitForSeconds(cooldown);
        readyAtk = true;
    }
}
