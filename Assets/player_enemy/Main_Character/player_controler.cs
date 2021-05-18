using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controler : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player;
    public float speed;
    private float moveInput;
    public float jumpForce;
    private bool isGrounded;
    private Animator anim;
    public Transform feetpos;
    public GameObject sword;
    public LayerMask whatIsGround;
    public float checkRadius;

    private bool dead;

    public int hp;
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    void FixedUpdate(){
        moveInput = Input.GetAxisRaw("Horizontal");
    }

    public void takeDamage()
    {
        if (dead == false)
        {
            hp += -1;
            anim.SetTrigger("hit");
        }

    }



    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetpos.position, checkRadius, whatIsGround);

        if (hp < 1 && dead == false)
        {
            anim.SetTrigger("Die");
            dead = true;
        }

        if(Input.GetKeyDown(KeyCode.Space) && dead == false)
        {
            anim.SetTrigger("attack");
            sword.GetComponent<swordScript>().attack();
            Debug.Log("ok");
        }
    
        if(isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow) && dead == false)
        {
            anim.SetTrigger("jump");
        }
        if (moveInput == 0 && dead == false){
            anim.SetBool("isRunning",false);
        }
        else
            anim.SetBool("isRunning",true);

        if (moveInput < 0 && dead == false)
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }
        else if (moveInput > 0 && dead == false)
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }
    }
}
