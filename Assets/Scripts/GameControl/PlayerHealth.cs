using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject blood;
    public Finish p;
    public float speed;
      public float health = 100;
     public  float maxHealth = 100;
    public int initialHealth = 3;
    int bigPotion = 3;
    int smallPotion = 3;
    [SerializeField] GameObject g;
    private SpriteRenderer rend;
    public GameObject endLevelUI;
   GameObject endLevelStars;
    bool takeDamaged;
     void Start()
    {
        if (PlayerPrefs.GetInt("generalHealth") == 0)
        {
            PlayerPrefs.SetInt("generalHealth",initialHealth);
        }
    rend=GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        LevelManage d = GameObject.Find("LevelManager").GetComponent<LevelManage>();
        if(health <=0||d.isFalled) {
           health = maxHealth;
           PlayerPrefs.SetInt("generalHealth", PlayerPrefs.GetInt("generalHealth") - 1);
            
          
        }
      

          PlayerPrefs.SetInt("genHeal", PlayerPrefs.GetInt("generalHealth"));
        //PlayerPrefs.SetInt("genHeal", generalHealth);

        if (Input.GetKeyDown(KeyCode.P)&&bigPotion>0)
        {
            health += 40;
            if(health>100)
            {
                health-=100;
                PlayerPrefs.SetInt("generalHealth", PlayerPrefs.GetInt("generalHealth") + 1);

            }
            bigPotion--;
        }
            
        if (Input.GetKeyDown(KeyCode.O) && smallPotion > 0)
        {
            health += 10;
            if (health > 100)
            {
                health -= 100;
                PlayerPrefs.SetInt("generalHealth", PlayerPrefs.GetInt("generalHealth") + 1);
            }
            smallPotion--;
        }
            
        if (p.passed)
        {
         Invoke("DestroyObj", 1.5f);
         Invoke("endLevelShowUI", 2.74f);
        }
        else if(d.dead)
        {
            Invoke("endLevelShowUI", 1f);
        }
        PlayerPrefs.SetFloat("playerHealth", health);
    }
    private void DestroyObj()
    {
        if (Vector2.Distance(transform.position, g.transform.position) < 100)
        {
            StartFading();
            Destroy(gameObject, 1.25f);
            
        }
    }
    IEnumerator FadeOut()
    {
        for(float f = 1.0f; f >=-0.05f; f -= 0.05f) {
        Color c=rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
       
    }
    public void endLevelShowUI()
    {
       
        endLevelUI.SetActive(true);
        GameObject.Find("PauseButton").SetActive(false);
        
    }
    public void StartFading()
    {
        StartCoroutine(FadeOut());
    }
    public void activateAnimator()
    {
        gameObject.GetComponent<Animator>().enabled = true;
        gameObject.GetComponent<Animator>().Play("Base Layer.penguin_idle", 0, 0);
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("CatEnemy"))
        {
            health -= 0.25f;
            TakeDamageP(true);
            blood.SetActive(true);
            blood.transform.position = transform.GetChild(3).transform.position;

        }
    }
    public void TakeDamageP(bool isPunched)
    {
        takeDamaged = isPunched;
    }
    private void OnAnimatorMove()
    {
       
       
        
    }





}
