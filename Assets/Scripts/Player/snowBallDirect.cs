using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowBallDirect : MonoBehaviour
{

    
    // Start is called before the first frame update
   Rigidbody2D rb;
    bool hasHit;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (!hasHit)
        {
          float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x);
          transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
          
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            hasHit = true;
            
          
        }



    }
}
