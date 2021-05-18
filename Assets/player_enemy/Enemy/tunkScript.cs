using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tunkScript : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject tunk;


    public Animator animator;

    public float attackSpeed;

    public int hp;
    private float timer;

    private bool isShooting;

    void Start()
    {
        timer = 0;

        isShooting = false;
    }

    public void takeDamage()
    {
        hp += -1;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > attackSpeed) 
            animator.SetTrigger("attack");
            isShooting = true;
            
 
        if (hp == 0)
        {
            Destroy (tunk); 
        }
    }

    void OnTriggerEnter2D (Collider2D Info)
    {
        if (Info.tag == "enemy")
            Physics2D.IgnoreCollision(Info.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        if (Info.tag == "Player")
            Info.GetComponent<player_controler>().takeDamage();
    }

}
