using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeEquipment : MonoBehaviour
{
    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
           
          
            
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
           
       

        }
            
    }
}
