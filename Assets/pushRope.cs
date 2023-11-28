using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushRope : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float horizontalSpeed,verticalSpeed;
    float xValue;
    [SerializeField] Transform player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        xValue = Input.GetAxis("Horizontal");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (xValue != 0)
            {
                Debug.Log("RopeForceUygulandı");
                rb.AddTorque(xValue * horizontalSpeed * Time.deltaTime);
            }
        }
    }
}
