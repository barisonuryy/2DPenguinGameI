using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clawAttack : MonoBehaviour
{
    public int clawDamage = 20;
    public int clawRageDamage = 30;
    public Vector3 attackoffSet;
    public float attackRange;
    public float clawattackRange;
    public LayerMask attackMask;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (GameObject.Find("Kinder").GetComponent<PlayerHealth>().health < 50)
        {
            anim.SetBool("isEnraged", true);
        }*/
    }
    public void Attack()
    {
        Vector3 pos=transform.position;
        pos += transform.right * attackoffSet.x;
        pos += transform.up * attackoffSet.y;
        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().health -= clawDamage;
        }
    }
    public void enAttack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackoffSet.x;
        pos += transform.up * attackoffSet.y;
        Collider2D colInfo = Physics2D.OverlapCircle(pos, clawattackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().health -= clawRageDamage;
        }
    }
}
