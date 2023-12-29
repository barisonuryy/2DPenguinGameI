using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinAttack : MonoBehaviour
{
   public GameObject Arrow;
    public float launchForce;
    public Transform shotPoint;
    public GameObject point;
    GameObject[] points;
    public int numberofPoints;
    public float spaceBetweenPoints;
    Vector2 direction;
    private float dirPlayer;
    private float constantDir;
    Vector2 mousePosition;
    Vector2 direcPosition;
    private float coolDownWeap;
    public AnimationClip animationClip;
    float weapTime;
    [SerializeField] private Transform playerPos;

    void Start()
    {
        weapTime = 0;
        points = new GameObject[numberofPoints];
        for (int i = 0; i < numberofPoints; i++)
        {
            points[i] = Instantiate(point, transform.position, Quaternion.identity);
        }

        coolDownWeap = animationClip.length;


    }

    // Update is called once per frame
    void Update()
    {
        
        dirPlayer = transform.root.localScale.x;
       
        Vector2 gunPosition = transform.position;
        direcPosition = gunPosition - new Vector2(playerPos.position.x, playerPos.position.y);
        direction = Mathf.Sign(dirPlayer)*Mathf.Ceil(Mathf.Abs(dirPlayer))*direcPosition;
        transform.right = direction;
       

        if (Time.time > weapTime)
        {
 
            weapTime = Time.time + coolDownWeap;
            Shoot();
           
        }

        for (int i = 0; i < numberofPoints; i++)
        {
            points[i].transform.position = pointPosition(i * spaceBetweenPoints);
        }
    }
    void Shoot()
    {
        GameObject newSB = Instantiate(Arrow, shotPoint.position,shotPoint.rotation);
        newSB.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
       
 
    }
    Vector2 pointPosition(float t)
    {
        Vector2 position = (Vector2)transform.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;

    }
   

}
