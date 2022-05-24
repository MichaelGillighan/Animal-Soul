using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Transform firePoint;
    public GameObject bulletPrefab;
    public KeyCode attack;
    public float interval = .2f;
    float nextShot = 0f;
    public Animator animator;
    private bool fire = false;


    void Start()
    {
        //DamageShoot = GetComponent<PlayerController>().Damage;
    }

    void Update ()
    {       
        Physics2D.IgnoreLayerCollision(10, 11);
        Physics2D.IgnoreLayerCollision(8, 10);
        Physics2D.IgnoreLayerCollision(9, 10);
        

        animator.SetBool("Fire", fire);
        if (Input.GetKeyDown(attack))
        {
            animator.SetBool("Fire", true);
            if (Time.time >= nextShot)
            {
                nextShot = Time.time + interval;
                Shoot();
            }

        }
        else
            animator.SetBool("Fire", false);
	}

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

}
