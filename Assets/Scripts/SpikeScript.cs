using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.layer == 3 || collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            if (collision.gameObject.CompareTag("Player"))
            {
                playerScript.healthPoints -= 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
