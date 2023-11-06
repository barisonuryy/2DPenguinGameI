using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class goblinRangeAttack : MonoBehaviour
{
    [SerializeField] GameObject player;
    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 0.0025f;
    private Rigidbody2D rb;
    public float distanceToAttack = 5f;
    public float distanceToStop = 3f;
    [SerializeField] Transform firingPoint;
    public float fireRate;
    private float timeToFire;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeToFire = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }
        if (Vector2.Distance(target.position, transform.position) <= distanceToStop)
        {
            Shoot();
        }
    }
    
    private void FixedUpdate()
    {
        if(Vector2.Distance(target.position, transform.position)>=distanceToStop)
        {
            rb.velocity = transform.up * speed;
        }
       
    }
    private void Shoot()
    {
        if (timeToFire <= 0f)
        {
            Debug.Log("Shoot");
            timeToFire = fireRate;

        }
        else
        {
            timeToFire-=Time.deltaTime;
        }
    }
   private void RotateTowardsTarget()
    {
        Vector2 targetDirection=target.position-transform.position;
        float angle=Mathf.Atan2(targetDirection.y, targetDirection.x)*Mathf.Rad2Deg-90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);

    }
    private void GetTarget()
    {
        if (player != null)
        {
            target = player.transform;
        }

    }
}
