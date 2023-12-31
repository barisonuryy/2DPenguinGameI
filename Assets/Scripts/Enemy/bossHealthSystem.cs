using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class bossHealthSystem : MonoBehaviour
{
    public float bossHealth = 200;
    bool damage;
    bool isVulnerable;
    public float maxHealth;
    Animator anim;
    private float vectorPlayer;
    private AnimationClip _animationClip;

    private bool isAttacking;
    public float checkCoolDown ;
    public float dirPlayer;
    Transform player;
    Rigidbody2D rb;
    bool canExplosive;
    public GameObject playerM;
    public bool startLightBoltTrip;
    public bool isWeak;

    BoxCollider2D bc2d;
    bool madHeal;
    private float cdHeal;
    public float coolDownHeal;
    public GameObject bossHealthbar,lightBolt,teleport;
    // Start is called before the first frame update
    void Start()
    {
        cdHeal = 0;
       bc2d = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        player = playerM.transform;
        anim = GetComponent<Animator>();
        checkCoolDown = 2f;
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

       
        isAttacking = playerM.GetComponent<BasicMech>().attack;
        vectorPlayer = playerM.GetComponent<Transform>().localScale.x;
     
        StartCoroutine(updateHealAn());
        if (bossHealth < 100 && cdHeal < Time.time)
        {
            cdHeal= Time.time+coolDownHeal;
            bossHealth++;
        }
   
    
        if(bossHealth<= 0)
        {

            
          anim.SetBool("isDead",true);
            teleport.SetActive(true);
            Destroy(gameObject,3f);
            
        }
        if (bossHealth <= 50)
        {

            startLightBoltTrip = true;
            isWeak = true;
        }
        if (bossHealth <= 35)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
      
        
    }
  
    // ReSharper disable Unity.PerformanceAnalysis
    private IEnumerator updateHealAn()
    {
  
        if (bossHealth == 100)
        {
            
            isVulnerable = true;
            anim.SetBool("madTime", true);
            yield return new WaitForSeconds(1f);
            isVulnerable = false;
           
          

        }
     
        
       
    }

    public void TakeDamage(float attackPower)
    {
        bossHealth -= attackPower;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            if (!isVulnerable)
            {
               
                bossHealth -= 10;
                Destroy(collision.gameObject, 0.01f);
            }
       
        }
       
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        
        if (other.collider.CompareTag("Player"))
        {
            
            
            if (!isVulnerable&&isAttacking)
            {
                

                if (Time.time > checkCoolDown)
                {
                    checkCoolDown = Time.time + 2f;
                    StartCoroutine(throwCharacter(800f,1200f,1));
                }
                    
                
            }
          
                

        }
    
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            checkCoolDown = Time.time;
        }  
    }
    public IEnumerator throwCharacter(float verticalPush,float horizontalPush,float decHealth)
    {
        playerM.GetComponent<BasicMech>().enabled = false;
        playerM.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2((-10 / 4) * vectorPlayer * horizontalPush, verticalPush));
        playerM.GetComponent<PlayerHealth>().health -= decHealth;
        yield return new WaitForSeconds(0.5f);
        playerM.GetComponent<BasicMech>().enabled = true;
       
    }
   private void OnDestroy()
    {
        Destroy(bossHealthbar);
        GameObject[] DestroyerLightB;
        DestroyerLightB = GameObject.FindGameObjectsWithTag("LightBolt");
        foreach(GameObject ob in DestroyerLightB)
        {
            Destroy(ob);
        }
    }
}