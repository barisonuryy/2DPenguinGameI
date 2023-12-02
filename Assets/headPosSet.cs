using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headPosSet : MonoBehaviour
{
    Vector3 tempPosN, tempPosP;
    // Start is called before the first frame update
    void Start()
    {
       tempPosN = transform.localPosition*(Vector2.left+Vector2.up);
        tempPosP = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
   float direction=Mathf.Sign(transform.parent.localScale.x);
        if (direction < 0)
        {
            transform.localPosition = tempPosN;
        }
        else if(direction>0)
        {
            transform.localPosition = tempPosP;
        }
    
        
      
    }
}
