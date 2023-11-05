using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collideControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       /* if (collision.collider.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject,0.5f);
        }*/
    }
}
