﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frutinha : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
     void OnTriggerEnter2D(Collider2D collider)
     {
         if(collider.gameObject.tag == "Player")
         {
             sr.enabled = false;
             circle.enabled = false;
             collected.SetActive(true);

             Destroy(gameObject, 0.6f);
         }
     }
}
