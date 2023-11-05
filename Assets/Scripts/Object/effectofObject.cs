using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class effectofObject : MonoBehaviour
{

    // Start is called before the first frame update
    public float verticalSpeed;
    public bool isLadder;
    float direction;
    Rigidbody2D rb;
    ladderControl check;
    void Start()
    {
      rb= GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Vertical");


        isLadder = false;
        if (isLadder)
        {
            if(direction > 0)
            {
                rb.gravityScale = 0f;
                rb.velocity = new Vector2(rb.velocity.x, verticalSpeed * direction);
            }
            if (direction < 0)
            {
                rb.gravityScale = 3f;
                rb.velocity = new Vector2(rb.velocity.x, verticalSpeed * direction);
            }
            if(direction==0)
            {
                rb.gravityScale = 0f;
                rb.velocity = Vector2.zero;
            }
            Debug.Log("KOSULLAR UYGULANDI");
            
        }
        else
        {
            rb.gravityScale = 5f;
        }
    }
    
   
}
