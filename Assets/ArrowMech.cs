using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ArrowMech : MonoBehaviour
{
    Rigidbody2D rb;
    float moveSpeed = 7f;
    Vector2 moveDirection;
    
    [SerializeField] float rotSpeed;
    [SerializeField] float rotModifier;
    [SerializeField] Transform player;
    [SerializeField] GameObject playerPrefab;
    private void Awake()
    {
        if (playerPrefab != null)
        {
            Vector3 toTarget = player.position - transform.position;
            float angle = Mathf.Atan2(toTarget.y, toTarget.x) * Mathf.Rad2Deg * rotModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotSpeed);
        }
    }
    void Start()
    {
   
        
        rb = GetComponent<Rigidbody2D>();
        moveDirection=(player.position-transform.position).normalized*moveSpeed;
        float yPower=player.position.y-transform.position.y-1.38f;
        yPower = Mathf.Abs(yPower)*0.5f;
        Debug.Log("Gücün değeri:::" + yPower);
        rb.velocity = new Vector2(moveDirection.x*4,moveDirection.y*(0.75f+yPower));
        if (gameObject.name != "arrow rot") 
        Destroy(gameObject, 2f);
        
    }
    private void FixedUpdate()
    {
      
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
