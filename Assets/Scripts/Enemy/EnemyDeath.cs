using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
    
{
    [SerializeField] GameObject smoke;
    GameObject enemy;
    public float deathTime = 0;
    bool damage = false;
    public LevelManage enemyDeathScore;
    // Start is called before the first frame update
    void Start()
    {
        enemy = gameObject.transform.parent.gameObject;
        
        
    }
    
    private void OnDestroy()
    {
        damage = false;
        enemyDeathScore.score += 100;
    }

    private void Update()
    {
       
    }
    

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            smoke.SetActive(true);
            smoke.transform.position=transform.GetChild(0).position;
            Destroy(enemy);
        }
    }
   public void TakeDamage(bool damaged)
    {
       damage= damaged;
       /*if (damage) 
           Destroy(enemy,deathTime);*/
    }
   
}
