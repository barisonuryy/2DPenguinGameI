using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEffect : MonoBehaviour
{
    [SerializeField] float slideSpeed;
    [SerializeField] GameObject ladder;
    [SerializeField] float rotateSpeed;
    public bool isShiftable;
    // Start is called before the first frame update
    void Start()
    {
        isShiftable = false;
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = transform.GetChild(0).transform.localPosition.x;
        if (isShiftable&&xValue<=1.17f)
        {
            transform.GetChild(0).transform.Translate(Vector2.right*Time.deltaTime*slideSpeed);
        }
        else if (isShiftable&&!(xValue<=1.17f))
        {
          
                foreach (var item in GameObject.FindGameObjectsWithTag("Obstacle1"))
                {
                item.GetComponentInChildren<trapMech>().enabled = false;  
                if (item.transform.GetChild(0).eulerAngles.z!=0 )
                {
                    item.transform.GetChild(0).rotation= Quaternion.RotateTowards(item.transform.GetChild(0).rotation, Quaternion.Euler(Vector3.zero), Time.deltaTime*60);
                  
                }
               
                   
                

                if (item.transform.position.y<=-3.6f)
                item.transform.Translate(Vector2.up*Time.deltaTime*1.5f);
                }
            
        }
       
        
    }
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
           
            isShiftable = true;
            ladder.SetActive(true);
        }
    }




}
