using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class couriMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.8f;
    public float range = 3f;
    float startingX;
    int dir = 1;
   public bool canTurn;
    void Start()
    {
        startingX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime * dir);
        if (transform.position.x < startingX || transform.position.x > range + startingX)
        {
            canTurn= true;
            dir *= -1;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
         
        collision.gameObject.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
            
        collision.gameObject.transform.SetParent(null);
    }
   
}
