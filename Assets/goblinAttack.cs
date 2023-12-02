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
    [SerializeField] Transform bowT;
    [SerializeField] GameObject playerPrefab;
    Animator anim;
   public bool isInRange;

    private void Start()
    {
        anim=transform.root.GetComponent<Animator>();
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
        if (Time.time>nextFire)
        {

         Instantiate(arrow, bowT.position, Quaternion.identity);
         nextFire = Time.time + fireRate;
            
            
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(gameObject.transform.root.position, dangerArea);
    }
    private void FixedUpdate()
    {
      
    }


}
