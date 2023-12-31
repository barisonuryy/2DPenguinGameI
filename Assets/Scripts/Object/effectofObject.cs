using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class effectofObject : MonoBehaviour
{

    // Start is called before the first frame update
    bool isSeqComplete;
    bool canUseCollision;
    public float verticalSpeed;
    public bool isLadder;
    float directionY,directionX;
  public  bool inRope;
    Collider2D cdRope;
    Rigidbody2D rb;
    BoxCollider2D bc2d;
    CapsuleCollider2D cc2d;
    FixedJoint2D fj;
   [SerializeField] GameObject check;
    Rigidbody2D rope;
    Transform ropeT;
    float xPosition,yPosition;
[SerializeField] float horizantalSpeedR, horizantalSpeedP,verticalSpeedP;

    void Start()
    {
        canUseCollision = true;
        inRope = false;
      rb= GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        cc2d = GetComponent<CapsuleCollider2D>();
      fj= GetComponent<FixedJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        directionY = Input.GetAxis("Vertical");
        directionX = Input.GetAxis("Horizontal");
        isLadder = check.GetComponent<ladderControl>().isClimable;
        if (isLadder)
        {
            if (directionY > 0)
            {
                rb.gravityScale = 0f;
                rb.velocity = new Vector2(rb.velocity.x, verticalSpeed * directionY);
            }
            if (directionY < 0)
            {
                rb.gravityScale = 3f;
                rb.velocity = new Vector2(rb.velocity.x, verticalSpeed * directionY);
            }
            if (directionY == 0)
            {
                rb.gravityScale = 0f;
                rb.velocity = Vector2.zero;
            }
          

        }
        else
            rb.gravityScale = 5f;



      if(inRope)
        {
            

            //rope.AddRelativeForce(new Vector2(horizantalSpeedR*directionX* Time.deltaTime, 0));
            

            if (Input.GetKey(KeyCode.Space)&&Input.GetAxis("Horizontal")!=0){
               
             StartCoroutine(jumpToRope());

            }
        }
          
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Rope")&& canUseCollision)
        {
            
            fj.enabled = true;
            inRope = true;
            rope = collision.rigidbody;
            cdRope = collision.collider;
            ropeT = collision.transform;
            fj.connectedBody = rope;
            cdRope=collision.collider; 
          
           
         

        }
      else  if (collision.collider.CompareTag("Rope") && !canUseCollision)
        {
            collision.collider.isTrigger = true;
        }
      
    }
  

    
    IEnumerator jumpToRope()
    {
        inRope = false;
        fj.connectedBody = null;
        fj.enabled = false;
        bc2d.isTrigger = true;
        cc2d.isTrigger = true;
        cdRope.isTrigger = true;
        transform.rotation = Quaternion.Euler(0,0,0);
        GetComponent<BasicMech>().enabled = false;
        rb.velocity=new Vector2(horizantalSpeedP*directionX,verticalSpeedP);
        yield return new WaitForSeconds(1.5f);
        GetComponent<BasicMech>().enabled = true;
        cdRope.isTrigger = false;
        bc2d.isTrigger = false;
        cc2d.isTrigger = false;
        canUseCollision =true;
        
    }

   



}
