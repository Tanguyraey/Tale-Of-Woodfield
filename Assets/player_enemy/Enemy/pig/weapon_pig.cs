using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_pig : MonoBehaviour
{
    public Transform firePoint;
    public GameObject pig;

    private bool single_bullet;
    public GameObject bulletPrefab;

    private float timer;
    bool tempo = false;

    void Start()
    {
        single_bullet = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if (pig.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Hit") && single_bullet ==false)
        {
            timer += Time.deltaTime;
            if (timer > 0.3)
            {
              Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
              single_bullet = true;
            }
        }
        if (pig.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Pig") && single_bullet == true)
            single_bullet = false;
    }
}
