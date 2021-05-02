using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeScript1 : MonoBehaviour
{
    // Start is called before the first frame update

    private bool FacingLeft = true;
    public GameObject slime;

    public float turnAfter;
    public Animator animator;

    public float speed;

    public int hp;
    private float timer;

    void Start()
    {
        timer = 0;
        
    }

    void OnTriggerEnter2D (Collider2D Info)
    {
        Debug.Log(Info.name);
        if (Info.tag == "enemy")
            Physics2D.IgnoreCollision(Info.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        if (Info.tag == "Player")
            Info.GetComponent<player_controler>().takeDamage();
    }

    public void takeDamage()
    {
        hp += -1;
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
            Destroy (slime); 
        }
		if (!FacingLeft && speed < 0)
		{
			Flip();
		}
		else if (FacingLeft && speed > 0)
		{
			Flip();
		}
        slime.transform.position = new Vector3(slime.transform.position.x  + speed, slime.transform.position.y, slime.transform.position.z);
    }

    void Flip()
    {
		FacingLeft= !FacingLeft;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
    }
}
