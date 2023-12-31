using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControlArcher : MonoBehaviour
{
    public bool isInRange;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
