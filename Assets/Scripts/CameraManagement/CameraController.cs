using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector3 offset;
    public float followSpeed=0.125f;
    public GameObject fightArea;
    bool isInArea;
    public Vector3 vectorArea;
    void LateUpdate()
    {
        if(!isInArea)
        transform.position=Vector3.Lerp(target.position,target.position+offset,followSpeed);
    }
    private void Update()
    {
        isInArea = fightArea.GetComponent<startBossFight>().startBossF;
       if( isInArea )
        {
            transform.position = new Vector3(58.48f, -2.27f, -10f);
            gameObject.GetComponent<Camera>().orthographicSize = 2.8f;
            gameObject.transform.GetChild(0).transform.localScale = new Vector3(0.62f, 0.62f, 1);
        }
        else
        {
            gameObject.GetComponent<Camera>().orthographicSize = 5f;
            gameObject.transform.GetChild(0).transform.localScale = new Vector3(1.1f, 1.1f, 1);
        }
            


    }
}
