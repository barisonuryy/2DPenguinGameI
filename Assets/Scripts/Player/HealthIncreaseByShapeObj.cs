using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIncreaseByShapeObj : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerHealth decrease;
    

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            decrease.health -= 2;
        }
    }
}
