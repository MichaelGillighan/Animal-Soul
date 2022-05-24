using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed = 10, jumpForce = 10;
    public LayerMask playerMask;
    Transform myTrans, tagGround;
    private float moveInput;
    public Animator animator;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;

    public bool isGround = false;
    private Rigidbody2D myBody;
    private bool m_facingRight = true;

    public int health = 3;
    public GameObject[] hearts;


    public Text contadorLlaves;
    public Text mascotas;

    public GameObject keyController;
    private bool hudDamageAnim = false;
    public Animator hudAnim;
    public GameObject gameOverS;
    private bool alive = true;
    public GameObject gm;

    public Animator powerUpAnim;
    private bool powerUp = false;

    public Animator hurtAnim;
    private bool isHurt = false;

    public Animator deadAnim;
    private bool isDead = false;

    public int damage = 30;

    public int Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

    void Start ()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        myTrans = this.transform;
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
    }

    void Update()
    {
        CorazonesVisuales();
        contadorLlaves.text = keyController.GetComponent<PickUp>().KeyCount.ToString();
        mascotas.text = keyController.GetComponent<PickUp>().PetCount.ToString();

        hudAnim.SetBool("dmg", hudDamageAnim);

        powerUpAnim.SetBool("powerUp", powerUp);
    }

    void FixedUpdate ()
    {
        isGround = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask);

        animator.SetBool("isGround", isGround);
        if (isGround)
        {
            animator.SetBool("Jump", false);
        }
        else
        {
            animator.SetBool("Jump", true);
        }       
        if (Input.GetKey(left) && alive)
        {
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
            if (m_facingRight)
                Flip();
        }
        else if (Input.GetKey(right) && alive)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
            if (!m_facingRight)
                Flip();
        }


        animator.SetFloat("Speed", Mathf.Abs(myBody.velocity.x));
        if (Input.GetKeyDown(jump) && alive)
        {
            if (isGround)
            {
                Jump();
            }
        }
            
	}

    private void Flip()//nuevo
    {
        m_facingRight = !m_facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    public void Caer()
    {
        animator.SetBool("Jump", false);
        animator.SetBool("Caida", true);

        if (isGround)
        {
            animator.SetBool("Caida",false);
        }
    }

    public void Move(float horizontalInput)
    {
        Vector2 moveVel = myBody.velocity;
        moveVel.x = horizontalInput * speed;
        myBody.velocity = moveVel;
    }

    public void Jump()
    {
      myBody.velocity += jumpForce * Vector2.up;
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage();
        }

        if (other.gameObject.tag == "masterHand")
        {
            TakeDamage2();
        }

        if (other.gameObject.tag == "dead")
        {
            TakeDamage2();
        }

        if (other.gameObject.tag == "Key")
        {
            //Debug.Log("Llave cogida");
            other.gameObject.SetActive(false);
            //llaves++;
            keyController.GetComponent<PickUp>().KeyCount++;

            Instantiate(gm.GetComponent<GameManager>().Efects[0], transform.position, transform.rotation);
        }

        if (other.gameObject.tag == "Jail")
        {
            if (keyController.GetComponent<PickUp>().KeyCount > 0)
            {
                Rescue(other);
                other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                Instantiate(gm.GetComponent<GameManager>().Efects[2], transform.position, transform.rotation);
            }
        }

        if (other.gameObject.tag == "HealPickUp")
        {
            other.gameObject.SetActive(false);

            if (health < 3)
            {
                health++;
                Instantiate(gm.GetComponent<GameManager>().Efects[1], transform.position, transform.rotation);
            }

        }

        if (other.gameObject.tag == "powerPickupBroc")
        {
            other.gameObject.SetActive(false);
            Instantiate(gm.GetComponent<GameManager>().Efects[3], transform.position, transform.rotation);
            StartCoroutine(damageIncrement(15, 20));
        }

        if (other.gameObject.tag == "powerPickupSoda")
        {
            other.gameObject.SetActive(false);
            Instantiate(gm.GetComponent<GameManager>().Efects[3], transform.position, transform.rotation);
            StartCoroutine(damageIncrement(20,15));
        }

    }

    IEnumerator damageIncrement(int dmgRec, int duracion)
    {
        powerUp = true;
        Damage += dmgRec;

        yield return new WaitForSeconds(duracion);

        Damage -= dmgRec;
        powerUp = false;
    }

    public void Rescue(Collision2D other)
    {
        keyController.GetComponent<PickUp>().KeyCount--;
        other.gameObject.GetComponent<Jail>().RescueAnim();
        keyController.GetComponent<PickUp>().PetCount++;
    }

    public void TakeDamage()
    {

        if (GetComponent<GengibreShield>() != null && GetComponent<GengibreShield>().ReadyMantel)
        {
            GetComponent<GengibreShield>().ReadyMantel = false;
        }
        else
        {
            health -= 1;
            hudDamageAnim = true;
            animator.SetTrigger("Hurt");
            StartCoroutine(DamageAnim());
        }

    }

    public void TakeDamage2()
    {
        if (GetComponent<GengibreShield>() != null && GetComponent<GengibreShield>().ReadyMantel)
        {
            GetComponent<GengibreShield>().ReadyMantel = false;

            health -= 3;
            hudDamageAnim = true;
            StartCoroutine(DamageAnim());
        }
        else
        {
            health -= 3;
            hudDamageAnim = true;
            StartCoroutine(DamageAnim());
        }

        //if (GetComponent)
        //{

        //}
    }

    IEnumerator DamageAnim()
    {
        yield return new WaitForSeconds(1);
        hudDamageAnim = false;
    }

    public void CorazonesVisuales()
    {

        if (health == 3)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[2].SetActive(true);

            hearts[0].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            hearts[1].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            hearts[2].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        if (health == 2)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[0].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            hearts[1].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            hearts[2].GetComponent<Image>().color = new Color(0.254902f, 0.1529412f, 0.1529412f, 1);
        }
        if (health == 1)
        {
            hearts[0].SetActive(true);
            hearts[0].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            hearts[1].GetComponent<Image>().color = new Color(0.254902f, 0.1529412f, 0.1529412f, 1);
            hearts[2].GetComponent<Image>().color = new Color(0.254902f, 0.1529412f, 0.1529412f, 1);
        }
        if (health <= 0)
        {
            hearts[0].GetComponent<Image>().color = new Color(0.254902f, 0.1529412f, 0.1529412f, 1);
            hearts[1].GetComponent<Image>().color = new Color(0.254902f, 0.1529412f, 0.1529412f, 1);
            hearts[2].GetComponent<Image>().color = new Color(0.254902f, 0.1529412f, 0.1529412f, 1);
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        StartCoroutine(GameOverScreen());
        animator.SetTrigger("Dead");
    }
    IEnumerator GameOverScreen()
    {
        yield return new WaitForSeconds(3);
        gameOverS.SetActive(true);
    }
}
