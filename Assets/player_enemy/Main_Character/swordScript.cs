using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordScript : MonoBehaviour
{

    private bool attackMov = false;
    private float timer = 0;

    private Collider2D a;
    // Start is called before the first frame update

    public void attack()
    {
        attackMov = true;
        
        a.isTrigger = true;
        
    }

    void OnTriggerEnter2D (Collider2D Info)
    {
        Debug.Log("ici");
        Debug.Log(Info.name);
        if (Info.name == "Trunk")
            Info.GetComponent<tunkScript>().takeDamage();
        if (Info.name == "Ghost")
            Info.GetComponent<ghostScript>().takeDamage();
        if (Info.name == "Slime")
            Info.GetComponent<slimeScript1>().takeDamage();
        if (Info.name == "Pig")
            Info.GetComponent<pigScript>().takeDamage();
    }
    void Start()
    {
        a =  this.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (attackMov == true)
        {

            timer += Time.deltaTime;
            if (timer > 1)
            {
                a.isTrigger = false;
                timer = 0;
                attackMov = false;
            }
        }
    }
}
