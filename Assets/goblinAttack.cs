using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinAttack : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] float fireRate;
    [SerializeField] float nextFire;
    [SerializeField] Transform shotPoint;
    [SerializeField] Vector2 dangerArea;
    [SerializeField] LayerMask player;
    [SerializeField] float rotSpeed;
    [SerializeField] float rotModifier;
    [SerializeField] Transform playerT;
    [SerializeField] GameObject playerPrefab;
   
    bool isInRange;

    private void Start()
    {
        //fireRate = 1f;
        nextFire=Time.time;
    }
    private void Update()
    {
        isInRange = Physics2D.OverlapBox(gameObject.transform.root.position, dangerArea, 0, player);
        if(isInRange )
        CheckTimeToFire();
    }
    void CheckTimeToFire()
    {
        if (Time.time > nextFire)
        {
         Instantiate(arrow, transform.position+new Vector3(0,-1f,0), Quaternion.identity);
          
            nextFire = Time.time+fireRate;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(gameObject.transform.root.position, dangerArea);
    }
    private void FixedUpdate()
    {
        if (playerPrefab != null)
        {
            Vector3 toTarget = playerT.position - transform.position;
            float angle = Mathf.Atan2(toTarget.y, toTarget.x) * Mathf.Rad2Deg * rotModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotSpeed);
        }
    }


}
