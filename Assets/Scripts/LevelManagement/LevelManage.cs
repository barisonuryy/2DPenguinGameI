using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
using Image = UnityEngine.UI.Image;

public class LevelManage : MonoBehaviour
{
    // Start is called before the first frame update

    public PlayerHealth h;
    bool p;
    public AudioSource bgm;
    public AudioSource PauseClick;
    public int score;
    public bool dead;
    int ammoCount;
    GameObject bulletCopyUI;
    public GameObject bulletUIObj, bulletParent;
    bool isClicked;
    bool create=true, reloadedAmmos;
    bool startBL;
    GameObject[] lightBolts;
    public GameObject lightBolt,machineGun,boss;
    public bool isFalled;
    bool cCreatable;
    bool isIn;
    float bossHealth;
    public float value;

    void Start()
    {
     
        create = true;
       //Debug.unityLogger.logEnabled = false;
       if(SceneManager.GetActiveScene().buildIndex != 1)
        ammoCount =machineGun.GetComponent<weaponScript>().ammoCounter;
    }

    // Update is called once per frame
    void Update()
    {
        if (machineGun!=null)
        {
            reloadedAmmos = machineGun.GetComponent<weaponScript>().reloadedAmmo;
            ammoCount = machineGun.GetComponent<weaponScript>().ammoCounter;

        }

        if (reloadedAmmos)
        {
  
            create = true;
        }
        if (create)
        {
            createBulletUI();
        }
            
        create = false;


        // Orijinal düðmenin özelliklerini yeni düðmeye kopyalayý
        p = GetComponentInChildren<Finish>().passed;
        if (PlayerPrefs.GetInt("generalHealth") == 0)
        {
            //SceneManager.LoadScene("SampleScene");
            dead = true;
        }
  
        if (p)
        {
            bgm.Stop();
        }
        if(lightBolt!=null)
        cCreatable = lightBolt.GetComponent<lighBolt>().canCreatable;
        if(boss!=null)
        bossHealth= boss.GetComponent<bossHealthSystem>().bossHealth;
 
      
     
    }


    private void FixedUpdate()
    {
        if (!(ammoCount <= 0))
        {


        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //PlayerPrefs.SetInt("counterforH", PlayerPrefs.GetInt("counterforH") + 1);
            //Debug.Log("sayac degeri::::" + PlayerPrefs.GetInt("counterforH"));
            isFalled = true;
            SceneManager.LoadScene((SceneManager.GetActiveScene().name));

        }
        else isFalled = false;
    }

    private void showScore(int score)
    {

    }
    private void playScoreAnim()
    {

    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void pauseClick()
    {
        PauseClick.Play();
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void exitGame()
    {
        Application.Quit();

    }
    public void backHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void createBulletUI()
    {
        float distance,range;
        if(SceneManager.GetActiveScene().buildIndex != 1)
        {
            if (transform.GetChild(2).gameObject.activeInHierarchy)
                isIn = GetComponentInChildren<startBossFight>().startBossF;
        }
    
        if (isIn)
        {
            range = 3.25f;
            distance = value;

        }

        else
        {
            distance = 4.35f;
            range = 1.35f;
        }
        if(SceneManager.GetActiveScene().buildIndex != 1)
        {
            for (int i = bulletParent.transform.childCount - 1; i < ammoCount; i++)
            {

                bulletCopyUI = Instantiate(bulletUIObj, new Vector3(bulletUIObj.transform.position.x + distance + ((float)i / range), bulletUIObj.transform.position.y, bulletUIObj.transform.position.z), Quaternion.identity);

                bulletCopyUI.transform.SetParent(bulletUIObj.transform.parent);
                bulletCopyUI.transform.localScale = new Vector3(0.796875f, 0.778125f, 1);
            }
        }
      
    }
}
