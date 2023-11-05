using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dangerousWarning : MonoBehaviour
{
    GameObject kindd;
  public  bool isDangerous;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            isDangerous = true;



        }
       

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            isDangerous = true;
           
           
         
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            isDangerous = false;
    }
}
