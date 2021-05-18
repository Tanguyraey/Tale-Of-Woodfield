using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject tunk;

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
        if (tunk.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("tunk_fire") && single_bullet ==false)
        {
            timer += Time.deltaTime;
            if (timer > 0.3)
            {
              Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
              single_bullet = true;
            }
        }
        if (tunk.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("tunk") && single_bullet == true)
            single_bullet = false;
    }
}
