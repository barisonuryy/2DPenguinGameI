using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidePKey : MonoBehaviour
{
  
    // Update is called once per frame
    void Update()
    {
        bool isPressedB=gameObject.GetComponentInParent<ButtonEffect>().isShiftable;
        float xValue = transform.localPosition.x;
        if (xValue>= -0.581&&isPressedB)
        {
            transform.Translate(Vector2.left * Time.deltaTime);
        }
    }
   
}
// 0.784