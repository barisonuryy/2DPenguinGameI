using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitcherScriptControl : MonoBehaviour
{
    [SerializeField] private float RangePlayer;
    [SerializeField] private Transform Player;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<witcherMovement>().enabled = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<witcherMovement>().enabled = true;
            StartCoroutine(GetComponent<witcherMovement>().FirstForm());

        }
    }
    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("walk",true);
            if (Math.Abs(Player.position.x - gameObject.transform.position.x) > RangePlayer)
            {

                Vector2 targetPoint= Vector2.MoveTowards(gameObject.transform.position,
                    new Vector2(Player.position.x, gameObject.transform.position.y), Time.deltaTime);
                gameObject.transform.position = targetPoint;
            }
            if (Player.position.x - gameObject.transform.position.x < 0)
            {
                gameObject.transform.rotation=Quaternion.Euler(Vector3.zero);
            
            }
            else if (Player.position.x - gameObject.transform.position.x > 0)
            {
                gameObject.transform.rotation=Quaternion.Euler(0,180,0);
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("walk",false);
            GetComponent<witcherMovement>().enabled = false;
            
        }
    }
}
