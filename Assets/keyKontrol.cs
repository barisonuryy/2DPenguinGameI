using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyKontrol : MonoBehaviour
{
    bool haveKey;
    [SerializeField] GameObject key,keyUI;
   bool canPress;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(key != null) 
     haveKey=key.GetComponent<takeKey>().haveKey;
        
        if(haveKey && canPress&&transform.parent.transform.GetChild(0).transform.localPosition.y<4.4f)
        {
           
            transform.parent.transform.GetChild(0).transform.Translate(Vector2.up*Time.deltaTime);
            

        }
      
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&&Input.GetKey(KeyCode.E))
        {
            canPress=true;
            keyUI.gameObject.SetActive(!haveKey);
            transform.parent.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(haveKey);
            transform.parent.transform.GetChild(1).transform.GetChild(1).gameObject.SetActive(!haveKey);
        }
            

    }
  
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPress = false;
        }
    }

}
