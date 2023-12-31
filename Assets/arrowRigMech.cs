using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowRigMech : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;
    public GameObject point;
    GameObject[] points;
    public int numberofPoints;
    public float spaceBetweenPoints;
    Vector2 direction;
    private float dirGoblin;
    private float constantDir;
    Rigidbody2D rbWeap;
    [SerializeField] Transform playerPosition;
    [SerializeField] Transform bowTPosition;
    Vector2 direcPosition;
    public float coolDownWeap;
    float weapTime;
    [SerializeField] GameObject goblin;
    bool isInRng;
    bool isShoot;
    Vector2 bowTPos;
    private void Awake()
    {

    }
    void Start()
    {

       
        weapTime = 0;
        
        points = new GameObject[numberofPoints];
        for (int i = 0; i < numberofPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }
        rbWeap = GetComponent<Rigidbody2D>();
        bowTPos = bowTPosition.position;

    }

    // Update is called once per frame
    void Update()
    {

      
         dirGoblin= goblin.GetComponent<Transform>().localScale.x;
        constantDir = dirGoblin*2;
       

        direcPosition = new Vector2(playerPosition.position.x-bowTPos.x, (playerPosition.position.y - bowTPos.y)/3);
        direction = direcPosition;
        transform.right = direction;
        
  

        //transform.localScale = new Vector3(constantDir / 6, constantDir / 6, 1);
      


        if (isInRng)
        {

            for (int i = 0; i < numberofPoints; i++)
            {
                points[i].SetActive(true);
                isShoot = true;
               


            }
        }
        else
        {
            for (int i = 0; i < numberofPoints; i++)
            {
                points[i].SetActive(false);
                isShoot = false;



            }
        }

        if (isShoot&&Time.time>weapTime)
        {

            weapTime = Time.time + coolDownWeap;
            Shoot();
          
            
         


        }


        if (transform.eulerAngles.z > 90)
        {
            transform.Rotate(Vector3.zero);
        }
        for (int i = 0; i < numberofPoints; i++)
        {
            points[i].transform.position = pointPosition(i * spaceBetweenPoints);
        }
    }
    void Shoot()
    {
        GameObject newSB = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newSB.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;

        //Destroy(newSB, 2f);
       // isShooted = true;
    }
    Vector2 pointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    public static Quaternion LookAtTarget(Vector2 rotation)
    {
        return Quaternion.Euler(0, 0, Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg);
    }

}
