using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMech : MonoBehaviour
{
    Rigidbody2D rb;
    float moveSpeed = 7f;
    Vector2 moveDirection;
  
    [SerializeField] Transform player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDirection=(player.position-transform.position).normalized*moveSpeed;
        rb.velocity = new Vector2(moveDirection.x*4,-moveDirection.y/2);
        Destroy(gameObject, 35f);
        
    }

    // Update is called once per frame
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (!collision.collider.CompareTag("Player"))
        {
            hasHit = true;


        }*/



    }
}
