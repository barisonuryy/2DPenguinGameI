using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class BasicMech : MonoBehaviour
{
    // Start is called before the first frame update
    public float dirSlide;
    float directionX,directionY;
    Rigidbody2D rb;
    Vector2 movement;
    public bool move,attack,jump,slide;
    public float speed;
    Animator animator;
    public float cooldownAttack=5.0f;
    public float verticalS;
    public float horizontalS;
    public float totalDurationA = 0f;
    private bool isFacingRight = true;
    public Transform attackPos;
    public float attackRangeX;
    public float attackRangeY;
    public bool canDash = true;
    private bool isDashing;
    public  bool dashControl;
    public float dashingPower = 24f;
    public float dashingTime = 0.2f;
    private float dashingCoolDown = 3f;
    public BoxCollider2D bc2d;
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private LayerMask platformLayerMask1;
    [SerializeField] private LayerMask platformLayerMask2;
    [SerializeField] private TrailRenderer tr;
    public float glidingspeed;
    GameObject boss;

    private void Awake()
    {
        boss = GameObject.Find("partBoss");
        rb=GetComponent<Rigidbody2D>(); 
        bc2d=GetComponent<BoxCollider2D>();
    }
    void Start()
    {

        animator =GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        dashControl = false;
        if(isDashing)
        {
            return;
        }
        Movement();
        Attack();
        Jump(isGrounded());
        SlideE();
        Flip();

        //Glide();
         }
    void Movement()
    {

        directionX= Input.GetAxis("Horizontal");
  
        if (directionX!=0)
        {
            move =true;
        }
        else move=false;
     }
    // ReSharper disable Unity.PerformanceAnalysis
    void Attack()
    {

            if (Input.GetButton("Attack")&& Time.time > cooldownAttack)
            {
            cooldownAttack = Time.time + totalDurationA;
            Debug.Log("Atak Baþarili");
                attack = true;
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0);
                
                foreach (Collider2D enemy in enemiesToDamage)
                {
                if (enemy.gameObject != null)
                {
                    Debug.Log(enemy.gameObject.name);
                    string valueEnemy = enemy.gameObject.name;
                    if (enemy.gameObject.CompareTag("CatEnemy"))
                    {
                        Destroy(enemy, 0.05f);
                        //enemy.GetComponent<EnemyDeath>().TakeDamage(true);
                    }
                    else if (enemy.gameObject.name == "partBoss")
                    {
                        if (gameObject.GetComponent<skill_set>().isInIncrease)
                            enemy.GetComponentInParent<bossHealthSystem>().TakeDamage(15f);
                        else
                            enemy.GetComponentInParent<bossHealthSystem>().TakeDamage(5f);
                    }
                    else if (enemy.gameObject.name == "ColliderP1")
                    {
                        if (gameObject.GetComponent<skill_set>().isInIncrease) 
                        enemy.GetComponentInParent<bossHealthSystem>().TakeDamage(15f);
                        else
                            enemy.GetComponentInParent<bossHealthSystem>().TakeDamage(5f);
                    }
                    else if (enemy.gameObject.name == "ColliderP2")
                    {

                        enemy.GetComponentInParent<bossHealthSystem>().TakeDamage(35f);
                    }

                }
            }
                
            
            }
            else attack = false;

    }
    void Jump(bool isGrounded)
    {
        if (isGrounded && Input.GetButtonUp("Vertical"))
        {
            jump = true;
            directionY = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, verticalS);
        }
        else jump = false;
           
    }
    void Flip()
    {
        if(!isFacingRight&&directionX>0f||isFacingRight&&directionX<0f) {
            isFacingRight = !isFacingRight;
            Vector3 localScale= transform.localScale;
            localScale.x *= -1f;
            dirSlide = localScale.x;
            transform.localScale = localScale;
          }
        
    }
    private IEnumerator Slide()
    {
        dashControl = true;
        canDash= false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        move = false;
        if(boss!=null)
        boss.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale=originalGravity;
        isDashing = false;
        if(boss!=null)
        boss.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(dashingCoolDown);
        canDash = true;
    }
    private bool isGrounded()
    {
        float extraHeight = 3f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask);
        Vector3.Angle(Vector2.up,rb.velocity);

        return raycastHit.collider!=null;
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(directionX * horizontalS, rb.velocity.y);
        
    }
    private void OnAnimatorMove()
    {
        
        animator.SetBool("isWalking", move);
        animator.SetBool("isAttack", attack);
        animator.SetBool("isJump", jump);
        animator.SetBool("canSlide", slide);
    }
    private void OnDrawGizmos()
    {

        
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 0));
        
    }
    void SlideE()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash&& gameObject.GetComponent<skill_set>().mana>=10)
        {
            slide = true;
            StartCoroutine(Slide());

        }
        else slide = false;
        
    }
  /*  void Glide()
    {
        if (Input.GetButton("Jump") && rb.velocity.y <= 0)
        {

            rb.velocity = new Vector2(rb.velocity.x, -glidingspeed);
            if(dirSlide>0)
            gameObject.transform.rotation= Quaternion.Euler(0, 0, -90);
            if(dirSlide<0)
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
            rb.gravityScale = 0f;

        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            rb.gravityScale = 5f;
        }

    }*/

}
   
    

