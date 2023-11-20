using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public Vector3 offset;
    public float followSpeed=0.125f;
    public GameObject fightArea,buttonArea;
    bool isInArea,isInBArea;
    public Vector3 vectorArea;
    void LateUpdate()
    {
        if(!isInArea)
        transform.position=Vector3.Lerp(target.position,target.position+offset,followSpeed);
    }
    private void Update()
    {
        if(buttonArea != null)
        {
            isInBArea=buttonArea.GetComponent<areaCameraControl>().needWideCamAngel;
        }
        
        if(fightArea != null)
        isInArea = fightArea.GetComponent<startBossFight>().startBossF;
       if( isInArea&&SceneManager.GetActiveScene().buildIndex==2 )
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
       if(isInBArea)
        {
            gameObject.GetComponent<Camera>().orthographicSize = 7.5f;
            gameObject.transform.GetChild(0).transform.localScale = new Vector3(1.66f, 1.66f, 1);
            offset.x = 0;
        }
        else
        {
            gameObject.GetComponent<Camera>().orthographicSize = 5f;
            gameObject.transform.GetChild(0).transform.localScale = new Vector3(1.1f, 1.1f, 1);
            offset.x = 0;
        }
            


    }
}
