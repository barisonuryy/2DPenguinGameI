using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class areaCameraControl : MonoBehaviour
{
    public bool needWideCamAngel;
    // Start is called before the first frame update
    void Start()
    {
        needWideCamAngel = false;
    }

    // Update is called once per frame
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            needWideCamAngel = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        needWideCamAngel = false;
    }
}
