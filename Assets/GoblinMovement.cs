using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMovement : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float Range;

    private Animator anim;
    // Start is called before the first frame update
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("walk",true);
        if (Math.Abs(player.position.x - gameObject.transform.position.x) > Range)
        {

            Vector2 targetPoint= Vector2.MoveTowards(gameObject.transform.position,
                new Vector2(player.position.x, gameObject.transform.position.y), Time.deltaTime);
            gameObject.transform.position = targetPoint;
        }

        if (player.position.x - gameObject.transform.position.x < 0)
        {
            gameObject.transform.rotation=Quaternion.Euler(Vector3.zero);
            
        }
        else if (player.position.x - gameObject.transform.position.x > 0)
        {
            gameObject.transform.rotation=Quaternion.Euler(0,180,0);
        }
        
    }
}
