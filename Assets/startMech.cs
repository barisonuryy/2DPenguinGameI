using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startMech : MonoBehaviour
{
    public bool isInArea=false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            isInArea = true;
    }
}
