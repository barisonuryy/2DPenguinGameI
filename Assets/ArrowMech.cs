using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ArrowMech : MonoBehaviour
{
    // Start is called before the first frame update
       Rigidbody2D rb;
       bool hasHit;
       [SerializeField] private float turnSpeed;
       
       void Start()
       {
           rb = GetComponent<Rigidbody2D>();
       }
   
       // Update is called once per frame

       private void OnCollisionEnter2D(Collision2D collision)
       {
       
           if (!collision.gameObject.CompareTag("Player")&&!collision.gameObject.CompareTag("Archer"))
           {
               hasHit = true;
               Destroy(gameObject,0.25f);
           }

           if (!collision.gameObject.CompareTag("Player"))
           {
               gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
           }
           
       }

       private void OnCollisionExit2D(Collision2D other)
       {
           if (!other.gameObject.CompareTag("Player"))
           {
               gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
           }
       }

       private void FixedUpdate()
       {
           if (!hasHit)
           {
               float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x);
               transform.rotation = Quaternion.AngleAxis(angle*turnSpeed, Vector3.back);
               
             
           }
       }

}
