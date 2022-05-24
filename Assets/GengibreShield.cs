using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GengibreShield : MonoBehaviour {

    private bool readyMantel = true;

    public GameObject mantel;

    public int cooldown = 5;

    public Animator skillready;

    public bool ReadyMantel
    {
        get
        {
            return readyMantel;
        }

        set
        {
            readyMantel = value;
        }
    }

    void Start () {
		
	}
	
	void Update () {

        skillready.SetBool("ready", ReadyMantel);

        if (gameObject.layer == 8 && !ReadyMantel)
        {
            mantel.SetActive(false);
            StartCoroutine(CoolDown());
        }

	}

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(cooldown);
        ReadyMantel = true;
        mantel.SetActive(true);
    }

}
