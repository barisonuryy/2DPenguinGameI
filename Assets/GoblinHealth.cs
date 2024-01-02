using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float goblinHealth = 100f;
    public float goblinMaxHealth = 100f;
    [SerializeField] GameObject smoke;
    private bool isDead;
   

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        isDead = false;
        
        GetComponentInChildren<MinoHealthUI>().setHealthUI(goblinHealth,goblinMaxHealth);
    }

    private void Update()
    {
        
       
    }

    public void TakeDamageGoblin(float damage)
    {
        goblinHealth -= damage;
        GetComponentInChildren<MinoHealthUI>().setHealthUI(goblinHealth,goblinMaxHealth);
        if (goblinHealth <= 0&&!isDead)
        {
            GetComponentInChildren<goblinAttack>().enabled = false;
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
