using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightBoltExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("KARAKTERÝ HOPLATTIK");
            GetComponentInParent<lighBolt>().startThrow();
            GameObject.Find("Kinder").GetComponent<PlayerHealth>().health -= 5*Time.deltaTime;
            
            
        }
        
            
    }
}
