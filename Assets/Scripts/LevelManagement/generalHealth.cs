using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class generalHealth : MonoBehaviour
{
    bool dead;
    public GameObject player,healthBar,backGroundMusic,levelManage;
    bool isInArea;
    public Vector3 lScale;
    // Start is called before the first frame update
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LevelManage d = GameObject.Find("LevelManager").GetComponent<LevelManage>();
        if(SceneManager.GetActiveScene().buildIndex != 1)
        {
            if (levelManage.transform.GetChild(2).gameObject.activeInHierarchy)
                isInArea = d.gameObject.GetComponentInChildren<startBossFight>().startBossF;
        }
      
        if(isInArea)
        {
            gameObject.transform.localScale = lScale;
            gameObject.transform.localPosition=new Vector3(-8.7f,gameObject.transform.localPosition.y,gameObject.transform.localPosition.z);
        }

        if (PlayerPrefs.GetInt("genHeal") == 3)
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        if (PlayerPrefs.GetInt("genHeal") == 2)
        {
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        if(PlayerPrefs.GetInt("genHeal") == 1) {
            gameObject.transform.GetChild(2).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        if(PlayerPrefs.GetInt("genHeal") == 0)
        {
            for(int i = 0;i<3;i++)
            {
              gameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
            dead= true;
            d.dead = dead;
            player.GetComponent<PlayerHealth>().Invoke("endLevelShowUI", 0.5f);
            player.GetComponent<BasicMech>().enabled = false;
            backGroundMusic.GetComponent<AudioSource>().enabled = false;
            player.GetComponent<SFX>().enabled = false;
            PlayerPrefs.DeleteAll();
            Destroy(player,0.5f);
            
           healthBar.gameObject.SetActive(false);
        }
    }
}
