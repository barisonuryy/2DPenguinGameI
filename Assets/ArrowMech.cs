using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ArrowMech : MonoBehaviour
{
    Rigidbody2D rb;
    float moveSpeed = 7f;
    Vector2 moveDirection;

    [SerializeField] float Speed;
    float xPosPlayer,nextX,baseY;
    float xPosBow;
    float dis;
    float height;
    [SerializeField] float rotSpeed;
    [SerializeField] float rotModifier;
    [SerializeField] Transform player;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Transform bowT;
    Vector3 downPos;
    bool isHit;
    bool isFoundPlayer;
    [SerializeField] float fallSpeed;

    private void Awake()
    {

    }
    void Start()
    {
        isFoundPlayer = true;

        /* rb = GetComponent<Rigidbody2D>();
         moveDirection=(player.position-bowT.position).normalized*moveSpeed;

         //rb.AddRelativeForce(new Vector2(xPower * 30, yPower*20 ), ForceMode2D.Force);
         Debug.Log("moveDirectionDeger:::" + moveDirection);
         rb.velocity = transform.right*moveDirection*Time.deltaTime*Speed;*/



        //if (gameObject.name != "arrow rot") 
        //Destroy(gameObject, 1f);
        xPosPlayer = player.position.x;
        xPosBow = bowT.position.x;
        dis = xPosPlayer - xPosBow;

    }
    private void Update()
    {
        if (gameObject.name != "arrow rot"&&!isHit&&isFoundPlayer)
        {
         
            nextX = Mathf.MoveTowards(transform.position.x, xPosPlayer, Speed * Time.deltaTime);
            baseY = Mathf.Lerp(bowT.transform.position.y, player.position.y, (nextX - xPosBow) / dis);
            height = 2 * (nextX - xPosBow) * (nextX - xPosPlayer) / (-0.25f * dis * dis);
            Vector3 movePosition = new Vector3(nextX, baseY + height, transform.position.z);
            if(transform.position.x-player.transform.position.x > 0)
            transform.rotation = LookAtTarget(transform.position-movePosition);
            transform.position = movePosition;
            if (gameObject.name != "arrow rot")
            {
                //Destroy(gameObject,1.5f);
            }
            
        }
        if (transform.position.y <= player.position.y&& gameObject.name != "arrow rot")
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;

            isFoundPlayer = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.left + Vector2.down)*15;
           
        }
           
    }
    private void FixedUpdate()
    {
      
    }
    public static Quaternion LookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0,0,Mathf.Atan2(rotation.y,rotation.x)*Mathf.Rad2Deg);
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (gameObject.name != "arrow rot"&&gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            isHit = true;
            Destroy(gameObject,0.25f);
        }
        if (gameObject.name != "arrow rot" && !gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            Destroy(gameObject, 0.25f);
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (gameObject.name != "arrow rot")
        {
            
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Archer"))
        {
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
