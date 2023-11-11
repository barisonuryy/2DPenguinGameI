using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class trapMech : MonoBehaviour
{
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.eulerAngles = Vector3.forward*-90;
    }
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward*rotateSpeed*Time.deltaTime);
        float rot = transform.eulerAngles.z;

        Debug.Log("TrapRotateDegeri:::" + transform.eulerAngles.z);
        if (!((rot<= 90&&rot>=0)||(rot>=270&&rot<=360)))
        {
            
            rotateSpeed = -rotateSpeed;
        }
      
    }
}
