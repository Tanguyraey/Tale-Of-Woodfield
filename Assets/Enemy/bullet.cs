﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float timer = 0;
    public float speed = 20f;
    public Rigidbody2D rb;

    public GameObject bullet1;

    bool tempo = false;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void OnTriggerEnter2D (Collider2D Info)
    {
        Destroy(gameObject);
    }
}
