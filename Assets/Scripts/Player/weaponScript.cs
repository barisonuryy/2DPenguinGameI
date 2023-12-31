using System.Collections;
using System.Net;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;


public class weaponScript : MonoBehaviour
{
    public GameObject snowBall;
    public float launchForce;
    public Transform shotPoint;
    public GameObject point;
    GameObject[] points;
    public int numberofPoints;
    public float spaceBetweenPoints;
    Vector2 direction;
    private float dirPlayer;
    private float constantDir;
    public float minRotZ, maxRotZ, minRotZN, maxRotZN;
    private Transform tr;
    Vector2 mousePosition;
    private bool isShoot, isLimit;
    public bool haveAmmo;
    Rigidbody2D rbWeap;
    Vector2 direcPosition;
    public float coolDownWeap;
    float weapTime;
    public int ammoCounter;
    public bool reloadedAmmo, isShooted,isReloaded;

    [SerializeField] private LayerMask platformLayerMask;
    bool canChange;
 
    private void Awake()
    {
        
    }
    void Start()
    {

        isReloaded = true;
        canChange = true;
        weapTime = 0;
        tr = GetComponent<Transform>();
        points = new GameObject[numberofPoints];
        for (int i = 0; i < numberofPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }
        rbWeap = GetComponent<Rigidbody2D>();
        haveAmmo = true;

    }

    // Update is called once per frame
    void Update()
    {
        isShooted = false;
        reloadedAmmo = false;
        dirPlayer = transform.parent.GetComponent<Transform>().localScale.x;
        constantDir = dirPlayer * (10 / 4);
        Vector2 gunPosition = transform.position;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direcPosition = new Vector2(constantDir, (mousePosition.y - gunPosition.y) / 3);
        direction = direcPosition;
        transform.right = direction;
        limitateRot();

        transform.localScale = new Vector3(constantDir / 6, constantDir / 6, 1);
        if(Input.GetKeyDown(KeyCode.R)&& isReloaded)
        {
            isReloaded=false;
            StartCoroutine(reloadAmmo(ammoCounter));
        }
            

        if (isLimit)
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

        if (Input.GetMouseButtonDown(0) && isShoot && Time.time > weapTime && haveAmmo)
        {
 
            weapTime = Time.time + coolDownWeap;
            Shoot();
            ammoCounter--;
           
            if (ammoCounter <= 0&&isReloaded)
            {
                haveAmmo = false;
                isReloaded = false;
                StartCoroutine(reloadAmmo(0));
            }

        
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
        GameObject newSB = Instantiate(snowBall, shotPoint.position, shotPoint.rotation);
        newSB.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        Destroy(newSB,2f);
        isShooted = true;
    }
    Vector2 pointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    void limitateRot()
    {
        Vector3 limitEuler = tr.rotation.eulerAngles;

        if (constantDir < 0)
        {

            limitEuler.z = Mathf.Clamp(limitEuler.z, 110, 250);
            if (limitEuler.z == 110 || limitEuler.z == 250)
            {
                isLimit = false;


            }
            else
            {
                isLimit = true;

            }

        }
        if (constantDir > 0)
        {
            if (limitEuler.z > 180)
            {
                limitEuler.z -= 360;
            }
            limitEuler.z = Mathf.Clamp(limitEuler.z, minRotZ, maxRotZ);
            if (limitEuler.z == minRotZ || limitEuler.z == maxRotZ)
            {
                isLimit = false;

            }
            else
            {
                isLimit = true;

            }

        }

        tr.rotation = Quaternion.Euler(limitEuler);


    }
    IEnumerator reloadAmmo(int b)
    {
        for (int i = b; i < 5; i++)
        {
           
            yield return new WaitForSeconds(1f);
            if (ammoCounter < 5)
            {
                ammoCounter++;
               
                haveAmmo = true;
                reloadedAmmo = true;
            }

        }
        isReloaded = true;
    }

    private void OnDisable()
    {
        for (int i = 0; i < numberofPoints&&canChange; i++)
        {
            points[i].SetActive(false);
        }
    }
    private void OnEnable()
    {
        for (int i = 0; i < numberofPoints&&canChange; i++)
        {
            points[i].SetActive(true);
        }
    }
}
