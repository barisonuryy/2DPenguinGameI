using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossJump: StateMachineBehaviour
{
    public float speed = 2.5f;
    public float JumpForce = 10f;
   
    Transform player,bossTrnsform;
    Rigidbody2D rb;
    enemyMech turnFace;
   public bool isMad;
   private int count;
   public bool isAbove,canFall,isPlaying;
    public bool canExplode;
   
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        turnFace = animator.GetComponent<enemyMech>();
        bossTrnsform = animator.GetComponent<Transform>();
        

    }


    
 

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      
        Vector2 target = new Vector2(player.position.x, player.position.y);
        Vector2 newPos= Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        turnFace.LookAtPlayer();
        
        if (GameObject.Find("FightArea").GetComponent<startBossFight>().startBossF)
        {
            rb.MovePosition(new Vector2(bossTrnsform.position.x,(bossTrnsform.position.y+2f)*Time.fixedDeltaTime));
            isAbove = true;
            if (canFall)
                isPlaying = true;
                isAbove = false;
              rb.MovePosition(newPos);
        }
        /*if (Vector2.Distance(player.position, rb.position) <= 7f)
        {
            
            canExplode = true;
            //GameObject.FindGameObjectWithTag("Explosion").SetActive(true);
           // Debug.Log("Boss bombayı patlattı");
           // GameObject.FindGameObjectWithTag("Explosion").SetActive(true);
           // GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().health -= 5f;
            Debug.Log(canExplode+"DÖNEN DEĞER BU");
        }*/
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
              canFall = false;
              animator.SetBool("isJump",false);
              isPlaying = false;
              //GameObject.Find("expBoss").SetActive(false);

        Debug.Log("Alandan çıkılıyor");
        }
        
    }

  

