using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColliderS : MonoBehaviour
{
    [SerializeField] BoxCollider2D playerCollider;
    Vector2 defaulSize;
    // Start is called before the first frame update
    void Start()
    {
        defaulSize = playerCollider.size;
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
          
             playerCollider.size=new Vector2(0.5F, defaulSize.y);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            playerCollider.size = defaulSize;
        }
    }
}
