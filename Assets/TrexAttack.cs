using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrexAttack : MonoBehaviour
{
    Animator anim;
    private bool isJump,isPatrol;
    private float cdJump;
    Rigidbody2D rb;
    [Header("Time")]
    [SerializeField] float jumpCoolDown;
    [Header("For Petrolling")]
    [SerializeField] float moveSpeed;
    public float moveDirection = -1;
    private bool facingRight = false;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] Transform wallCheckPoint;
    [SerializeField] float circleRadius;
    private bool checkingGround;
    private bool checkingWall;


    [Header("For JumpAttacking")]
    [SerializeField] float jumpHeight;
    [SerializeField] Transform playerT;
    [SerializeField] Transform groundCheck;
    [SerializeField] Vector2 boxSize;
    [SerializeField] LayerMask groundLayer;
    private bool isGrounded;

    [Header("ForSeeingPlayer")]
    [SerializeField] Vector2 lineofSite;
    [SerializeField] LayerMask player;
    private bool canSeePlayer;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cdJump = 0;
    }

    // Update is called once per frame
    void Update()
    {
    
       
     


    }
    private void FixedUpdate()
    {
  
        checkingGround = Physics2D.OverlapCircle(groundCheckPoint.position, circleRadius, groundLayer);
        checkingWall = Physics2D.OverlapCircle(wallCheckPoint.position, circleRadius, groundLayer);
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundLayer);
        canSeePlayer = Physics2D.OverlapBox(transform.position, lineofSite, 0, player);

        
       
     
        if (!canSeePlayer&&isGrounded)
        {
            Patrolling();

        }
       else if(canSeePlayer)
        {
            FlipTowardsPlayer();
            JumpAttack();
        }
            








    }
    void JumpAttack()
    {
        float distanceFromPlayer = playerT.position.x - transform.position.x;
        if (isGrounded)
        {
            isJump = true;
            rb.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);

        }
        else isJump = false;
       
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheckPoint.transform.position, circleRadius);
        Gizmos.DrawWireSphere(wallCheckPoint.transform.position, circleRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundCheck.transform.position, boxSize);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, lineofSite);
    }
    void Patrolling()
    {
        
        if (!(checkingGround || checkingWall))
        {
            isPatrol = false;
            if (!facingRight)
            {
                Flip();
            }
            else if(facingRight) {
                Flip();
            }
            
        }
        isPatrol=true;
        rb.velocity = new Vector2(moveSpeed * moveDirection, rb.velocity.y);
    }
    void Flip()
    {
        moveDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    void FlipTowardsPlayer()
    {
        float playerPosition = playerT.position.x - transform.position.x;
            if (playerPosition < 0 && facingRight)
            {
                Flip();
            }
            else if (playerPosition > 0 && !facingRight)
            {
                Flip();
            }
        
     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    private void OnAnimatorMove()
    {
        anim.SetBool("iJump", isJump);
        anim.SetBool("iPatrol", isPatrol);
    }



}

