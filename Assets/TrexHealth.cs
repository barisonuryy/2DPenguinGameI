using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrexHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float trexHealth = 500f;
    public float trexMaxHealth = 500f;
    [SerializeField] GameObject smoke;
    private bool isDead;
   

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        isDead = false;
        
        GetComponentInChildren<MinoHealthUI>().setHealthUI(trexHealth,trexMaxHealth);
    }

    private void Update()
    {
        GetComponentInChildren<MinoHealthUI>().setHealthUI(trexHealth,trexMaxHealth);
       
    }

    public void TakeDamageTrex(float damage)
    {
        trexHealth -= damage;
       
        if (trexHealth <= 0&&!isDead)
        {
            GetComponent<TrexAttack>().enabled = false;
            GetComponentInChildren<tRexDamageEnemy>().enabled = false;
            Destroy(gameObject,1f);
            isDead = true;
        }
    }

    private void OnDestroy()
    {
        smoke.SetActive(true);
        smoke.transform.position=transform.root.position;
    }
}
