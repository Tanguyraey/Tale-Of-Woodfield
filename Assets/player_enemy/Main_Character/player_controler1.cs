using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controler1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float moveInput;
    public float jumpForce;
    private bool isGrounded;
    public Transform feetpos;
    public LayerMask whatIsGround;
    public float checkRadius;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void FixedUpdate(){
        moveInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    }



    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(feetpos.position, checkRadius, whatIsGround);


    
        if(isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow))
        {

            rb.velocity = Vector2.up * jumpForce;
        }

 

        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }
    }
}
