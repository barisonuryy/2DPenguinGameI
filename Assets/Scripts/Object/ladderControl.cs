using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladderControl : MonoBehaviour
{
    public bool isClimable;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isClimable = true;
        
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isClimable = false;
        }
    }


}
