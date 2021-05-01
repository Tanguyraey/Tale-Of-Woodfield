using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeScript : MonoBehaviour
{
    // Start is called before the first frame update

    private bool FacingLeft = true;
    public GameObject ghost;

    public float turnAfter;
    public Animator animator;

    public float speed;

    public int hp;
    private float timer;

    void Start()
    {
        timer = 0;
        
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (timer > turnAfter) 
        {
            speed = speed * -1;
            timer = 0;
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
}
