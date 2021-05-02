using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtleScript : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D Info)
    {
        if (Info.tag == "enemy")
            Physics2D.IgnoreCollision(Info.gameObject.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        if (Info.tag == "Player")
            Info.GetComponent<player_controler>().takeDamage();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
