using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float speedUpTimer;
    private bool FacingLeft = true;
    public GameObject ghost;

    public float turnAfter;
    public Animator animator;

    public float speed;

    public int hp;
    private float timer;

    private bool super;

    void Start()
    {
        timer = 0;
        super = false;
        
    }

    void OnTriggerEnter2D (Collider2D Info)
    {
        if (Info.tag == "enemy")
            Physics2D.IgnoreCollision(Info.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        if (Info.tag == "Player")
            Info.GetComponent<player_controler>().takeDamage();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > turnAfter) 
        {
            speed = speed * -1;
            timer = 0;
        }
        if ((timer >2 && timer < 2 + speedUpTimer) && super == false)
        {
            speed = speed*2;
            super = true;
        }

        if ((timer <2 || timer > 2 + speedUpTimer) && super == true)
        {
            speed = speed/2;
            super = false;
        }
            
 
        if (hp == 0)
        {
            animator.SetBool("isDead", true);
            Destroy (ghost, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length); 
        }
		if (!FacingLeft && speed < 0)
		{
			Flip();
		}
		else if (FacingLeft && speed > 0)
		{
			Flip();
		}
        ghost.transform.position = new Vector3(ghost.transform.position.x  + speed, ghost.transform.position.y, ghost.transform.position.z);
    }

    void Flip()
    {
		FacingLeft= !FacingLeft;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
    }

    public void takeDamage()
    {
        hp += -1;
    }
}
