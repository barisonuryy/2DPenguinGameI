using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class trapMech : MonoBehaviour
{
    [SerializeField] GameObject areaControl;
    public float rotateSpeed;
    bool isPlayerIn;
    // Start is called before the first frame update
    void Start()
    {
        isPlayerIn = false;   
    }

    // Update is called once per frame
    void Update()
    {
       // transform.eulerAngles = Vector3.forward*-90;
    }
    private void FixedUpdate()
    {
        isPlayerIn=areaControl.GetComponent<startMech>().isInArea;
      

     
        if (isPlayerIn)
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
            float rot = transform.eulerAngles.z;
            if (!((rot <= 90 && rot >= 0) || (rot >= 270 && rot <= 360)))
            {

                rotateSpeed = -rotateSpeed;
            }
        }
      
      
    }
  
}
