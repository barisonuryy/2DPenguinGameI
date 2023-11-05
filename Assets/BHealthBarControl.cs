using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BHealthBarControl : MonoBehaviour
{
    bool inArea;
    public GameObject fightArea;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        inArea = fightArea.GetComponent<startBossFight>().startBossF;
        gameObject.transform.GetChild(0).gameObject.SetActive(inArea);
       

    }
}
