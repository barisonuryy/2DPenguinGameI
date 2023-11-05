using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boltDamageScr : MonoBehaviour
{
    // Start is called before the first frame update
    public float coolDownExp;
    void Start()
    {
        coolDownExp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (Time.time > coolDownExp)
            {
                coolDownExp=Time.time+3f;
            }
        }
    }
}
