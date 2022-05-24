using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    private GameObject player;
    public float speed = 2;
    public int health = 100;
    private Transform target;
    private Transform target2;
    public float playerDistance;
    private float rangePlayer1, rangePlayer2;
    public PlayerController myPC;

    private Transform myTrans;
    private SpriteRenderer sR;
    private bool isWalking = false;
    private float enemyDistance, enemyDistance2;
    public float stoppingDistance;
    public Animator enemyAnim;
    public Collider enemyCollider;

    public BoxCollider2D box1;
    public BoxCollider2D box2;

    //private ri

    private bool isDead = false;

    public void TakeDamage()
    {
        if (!isDead)
        {
            health -= myPC.Damage;
            enemyAnim.SetTrigger("Hurt");
            if (health <= 0)
            {
                isDead = true;
                Die();
            }
        }
    }

    public void TakeDamageMouse()
    {
        if (!isDead)
        {
            health -= 100;
            if (health <= 0)
            {
                isDead = true;
                Die();
            }
        }

    }

    void Die()
    {
        box1.enabled = false;
        box2.enabled = false;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().mass = 20;
        enemyAnim.SetTrigger("Dead");
        Destroy(gameObject, 2);
    }
    

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        target2 = GameObject.FindGameObjectWithTag("Player 2").GetComponent<Transform>();
        sR = GetComponent<SpriteRenderer>();
        myTrans = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")       
            enemyAnim.SetTrigger("Punch");
        
        else if(other.tag == "Player 2")       
            enemyAnim.SetTrigger("Punch");
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")        
            enemyAnim.ResetTrigger("Punch");
        
        else if (other.tag == "Player 2")
            enemyAnim.ResetTrigger("Punch");
    }


    void FixedUpdate()
    {
        Physics2D.IgnoreLayerCollision(8, 15);
        Physics2D.IgnoreLayerCollision(9, 15);

        if (!isDead)
        {
            enemyAnim.SetBool("Walking", isWalking);
            enemyDistance = Vector2.Distance(transform.position, target.position);
            enemyDistance2 = Vector2.Distance(transform.position, target2.position);

            if (enemyDistance < playerDistance || enemyDistance2 < playerDistance)
            {
                enemyAnim.SetBool("Walking", true);
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), speed * Time.deltaTime);
            }

            else if(enemyDistance2 < playerDistance)
            {
                enemyAnim.SetBool("Walking", true);
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(target2.position.x, transform.position.y), speed * Time.deltaTime);
            }

            if (myTrans.transform.position.x > target.transform.position.x)
                sR.flipX = true;

            if (target.transform.position.x > myTrans.transform.position.x )
                sR.flipX = false;
        }
    }
}
