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

}
