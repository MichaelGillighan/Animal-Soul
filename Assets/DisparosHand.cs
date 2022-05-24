using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparosHand : MonoBehaviour {

    public Transform[] spawnShoot;
    public int health = 200;
    public GameObject bolita;
    public int tiempoDisparo = 4;

    public GameObject masterHand;
    public GameObject hand;
    public GameObject hand2;

    public PlayerController myPC;

    public GameObject[] explosiones;

    public int cantidadExplosiones = 10;

    public GameObject explo;
    public Transform[] ubicaExplo;
    private Animator anim;
    public GameObject fondoBlanco;
    public GameObject doggiJail;
    public GameObject doggiFree;

    public GameObject finalS;
    public GameObject mmenu;

    // Use this for initialization
    void Start () {

        anim = GetComponent<Animator>();

        StartCoroutine(AtaqueBolas());

        //cantidadExplosiones = 0;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator AtaqueBolas()
    {
        int x = Random.Range(0, spawnShoot.Length);
        yield return new WaitForSeconds(tiempoDisparo);
        InstanciarDisparos(spawnShoot[x]);
        StartCoroutine(AtaqueBolas());
    }

    public void InstanciarDisparos(Transform spawnShoot)
    {
        Instantiate(bolita, spawnShoot.position, spawnShoot.rotation);
    }

    public void TakeDamage()
    {
        health -= myPC.Damage;

        if (health <= 0)
        {
            StopAllCoroutines();
            masterHand.SetActive(false);
            hand.SetActive(true);

            GetComponent<BoxCollider2D>().enabled = false;

            StartCoroutine(Explosiones());

            //for (int i = 0; i < cantidadExplosiones; i++)
            //{
            //    //Instantiate(explo, ubicaExplo[i]);
            //    int x = Random.Range(0, ubicaExplo.Length);
            //    Instantiate(explo, ubicaExplo[x]);
          
            //}



            //StartCoroutine(ActivarExplosiones());
            //for (int i = 0; i < explosiones.Length; i++)
            //{
            //    ActivarExplosiones();
            //}
            //StopCoroutine(AtaqueBolas());
            //Die();
        }
    }

    public void TakeDamage2()
    {
        health -= 100;

        if (health <= 0)
        {
            StopAllCoroutines();
            masterHand.SetActive(false);
            hand.SetActive(true);

            GetComponent<BoxCollider2D>().enabled = false;

            StartCoroutine(Explosiones());

            //for (int i = 0; i < cantidadExplosiones; i++)
            //{
            //    //Instantiate(explo, ubicaExplo[i]);
            //    int x = Random.Range(0, ubicaExplo.Length);
            //    Instantiate(explo, ubicaExplo[x]);
            //}

            //StartCoroutine(ActivarExplosiones());
            //for (int i = 0; i < explosiones.Length; i++)
            //{
            //    ActivarExplosiones();
            //}

            //StopCoroutine(AtaqueBolas());
            //spawnShoot = null;
            //StartCoroutine(Explosiones());
            //Die();
        }
    }

    //public void ActivarExplosiones()
    //{
    //    for (int i = 0; i < explosiones.Length; i++)
    //    {
    //        for (int j = 0; j < explosiones.Length; j++)
    //        {
    //            //Instantiate(explosiones[i]);
    //            explosiones[j].SetActive(true);
    //            //explosiones[j].SetActive(false);

    //        }
    //        //explosiones[i].SetActive(false);
    //    }
    //}

    //IEnumerator ActivarExplosiones()
    //{
    //    for (int i = 0; i < explosiones.Length; i++)
    //    {
    //        for (int j = 0; j < explosiones.Length; j++)
    //        {
    //            //Instantiate(explosiones[i]);
    //            explosiones[j].SetActive(true);

    //        }
    //        //explosiones[i].SetActive(false);
    //        yield return new WaitForSeconds(1);
    //        explosiones[j].SetActive(false);
    //    }
    //}

    public void Die()
    {
        //gameObject.SetActive(false);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        hand.SetActive(false);
        hand2.SetActive(false);
    }

    IEnumerator TheEnd()
    {
        yield return new WaitForSeconds(7);
        finalS.SetActive(true);
        yield return new WaitForSeconds(13);
        mmenu.SetActive(true);
    }

    IEnumerator Explosiones()
    {
        anim.SetBool("Die", true);
        Instantiate(explo, ubicaExplo[0]);
        Instantiate(explo, ubicaExplo[1]);
        Instantiate(explo, ubicaExplo[2]);
        yield return new WaitForSeconds(1);
        fondoBlanco.SetActive(true);
        Instantiate(explo, ubicaExplo[3]);
        Instantiate(explo, ubicaExplo[4]);
        Instantiate(explo, ubicaExplo[5]);
        yield return new WaitForSeconds(1);
        Instantiate(explo, ubicaExplo[6]);
        Instantiate(explo, ubicaExplo[7]);
        yield return new WaitForSeconds(1);
        Die();
        doggiJail.SetActive(false);
        doggiFree.SetActive(true);
        StartCoroutine(TheEnd());
    }
}
