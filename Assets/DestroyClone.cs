using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyClone : MonoBehaviour
{
    bool isClicked;
    GameObject child;
    int ammoCount;
    bool shoot;
    public GameObject weapon, fightArea;
    bool isInArea;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isInArea = fightArea.GetComponent<startBossFight>().startBossF;
        int value = gameObject.transform.childCount - 1;
        shoot = weapon.GetComponent<weaponScript>().isShooted;
        ammoCount = weapon.GetComponent<weaponScript>().ammoCounter;
        child = gameObject.transform.GetChild(value).gameObject;

        if (shoot && value != 0)
        {
            Destroy(child);
        }
        if (isInArea)
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, 2.25f, gameObject.transform.localPosition.z) ;
            gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        }
        else
        {
            gameObject.transform.localScale = Vector3.one;
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, 2.04f, gameObject.transform.localPosition.z);
        }
            
    }
}
