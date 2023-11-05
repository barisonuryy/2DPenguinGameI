using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.eulerAngles=gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject.transform.eulerAngles;
        Quaternion.Euler(gameObject.transform.eulerAngles+new Vector3(0,0,-90));
    }
}
