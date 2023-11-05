using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class makeClone : MonoBehaviour
{
    public GameObject lightBollt, boss;
    GameObject[] lightBolts;
    bool cCreatable;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        float bossHealth = boss.GetComponent<bossHealthSystem>().bossHealth;
        cCreatable = lightBollt.GetComponent<lighBolt>().canCreatable;
        if (cCreatable && (bossHealth <= 50))
        {
            GameObject a=Instantiate(lightBollt, new Vector3(lightBollt.transform.position.x + Random.Range(1.5f, 2.5f), lightBollt.transform.position.y, 0), Quaternion.identity);
            a.gameObject.transform.GetChild(2).GetComponent<Renderer>().material.color = new Color(0, 5, 233, 221);
            GameObject b=Instantiate(lightBollt, new Vector3(lightBollt.transform.position.x - Random.Range(1.5f, 2.5f), lightBollt.transform.position.y, 0), Quaternion.identity);
            b.gameObject.transform.GetChild(2).GetComponent<Renderer>().material.color = new Color(0, 5, 233, 221);
            Destroy(gameObject);
            
        }
    }
}
