using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrexAttack : MonoBehaviour
{
  
    private float cdJump;
    bool isDangerous;
    Rigidbody2D rb;
    [Header("Time")]
    [SerializeField] float jumpCoolDown;
    [Header("For Petrolling")]
    [SerializeField] float moveSpeed;
    public float moveDirection = 1;
    private bool facingRight = true;
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

    // Start is called before the first frame update
    void Start()
    {
        cdJump = 0;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        isDangerous = gameObject.GetComponentInChildren<dangerousWarning>().isDangerous && cdJump < Time.time;




    }
    private void FixedUpdate()
    {
        checkingGround = Physics2D.OverlapCircle(groundCheckPoint.position, circleRadius, groundLayer);
        checkingWall = Physics2D.OverlapCircle(wallCheckPoint.position, circleRadius, groundLayer);
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundLayer);
        // Patrolling();
        Debug.Log("Velocity deger::" + rb.velocity);

        FlipTowardsPlayer();
        if (isDangerous)
        {
            cdJump = Time.time + jumpCoolDown;
            JumpAttack();
            

        }
        //else isJumped=false;

    }
    void JumpAttack()
    {
        float distanceFromPlayer = playerT.position.x - transform.position.x;
        if (isGrounded)
        {
            rb.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheckPoint.transform.position, circleRadius);
        Gizmos.DrawWireSphere(wallCheckPoint.transform.position, circleRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(groundCheck.transform.position, boxSize);
    }
    void Patrolling()
    {
        if (!checkingGround || checkingWall)
        {
            if (facingRight)
            {
                Flip();
            }
            else if (!facingRight)
                Flip();
        }
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



}

