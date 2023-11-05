using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startBossFight : MonoBehaviour
{
    float tempTime;
    // Start is called before the first frame update
    public bool startBossF,startLightB;
    public AudioSource music;
    private AudioSource music2;
    public GameObject boss,picture;
    public bool isPlaying=false;
    public GameObject teleport;
    public void Start()
    {
       music2=GetComponentInParent<LevelManage>().bgm;
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            music2.Stop();
            isPlaying = true;
            boss.SetActive(true);
            picture.SetActive(true);
            if (!music.isPlaying)
                music.Play();
            
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            startBossF = true;
           
            
        }
            
        if(collision.CompareTag("LightBolt"))
            startLightB = true;
        else
            startLightB= false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            tempTime=Time.time;
            if (Time.time - tempTime < 3f)
            {
                teleport.SetActive(false);
                startBossF = false;
                picture.SetActive(false);
            }
        }
     
    }
}
