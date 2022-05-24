using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterHand : MonoBehaviour {

    public GameObject posFinal;
    public GameObject posArriba;
    public GameObject posMedio;
    public GameObject posAbajo;

    private Rigidbody2D rb;

    public float speed = 1f;

    public int speedShoot = 3;

    private Animator deathPanchAnim;

    private Vector3 posPrede;


    void Start()
    {
        posPrede = gameObject.transform.position;

        rb = GetComponent<Rigidbody2D>();

        deathPanchAnim = GetComponent<Animator>();

        StartCoroutine(ArribaDisparo2());

    }


    void Update()
    {
        Physics2D.IgnoreLayerCollision(13, 14);
        Physics2D.IgnoreLayerCollision(13, 0);

        //Debug.Log(posPrede);

        posPrede.y = transform.position.y;

    }

    IEnumerator ArribaDisparo()
    {
        rb.velocity += speed * Vector2.up;
        yield return new WaitForSeconds(4);

        rb.velocity = Vector2.zero;

        StartCoroutine(ShootHand());
        yield return new WaitForSeconds(4);

        StartCoroutine(AbajoDisparo());

    }

    IEnumerator AbajoDisparo()
    {
        rb.velocity += speed * Vector2.down;
        yield return new WaitForSeconds(4);

        rb.velocity = Vector2.zero;

        StartCoroutine(ShootHand());
        yield return new WaitForSeconds(4);

        StartCoroutine(AbajoDisparo2());

    }

    IEnumerator AbajoDisparo2()
    {
        rb.velocity += speed * Vector2.down;
        yield return new WaitForSeconds(4);

        rb.velocity = Vector2.zero;

        StartCoroutine(ShootHand());
        yield return new WaitForSeconds(4);

        StartCoroutine(ArribaDisparo2());

    }

    IEnumerator ArribaDisparo2()
    {
        rb.velocity += speed * Vector2.up;
        yield return new WaitForSeconds(4);

        rb.velocity = Vector2.zero;

        StartCoroutine(ShootHand());
        yield return new WaitForSeconds(4);

        StartCoroutine(ArribaDisparo());

    }

    public IEnumerator ShootHand()
    {
        deathPanchAnim.SetBool("Pucnh", true);

        rb.velocity += speedShoot * Vector2.left;
        yield return new WaitForSeconds(1);

        rb.velocity = Vector2.zero;

        rb.velocity += speedShoot * Vector2.right;
        yield return new WaitForSeconds(1);

        rb.velocity = Vector2.zero;

        deathPanchAnim.SetBool("Pucnh", false);

        transform.SetPositionAndRotation(posPrede, transform.rotation);

        //transform.position.x = posPrede.x;

        //transform.position.x = -1.17f;

        //transform.Translate(-1.71f , transform.position.y, transform.position.z);
        //transform.Translate(posPrede.position.x, 0, 0);

        //transform.position.x = posPrede.position.x;
    }

}
