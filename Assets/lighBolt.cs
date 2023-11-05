using DigitalRuby.LightningBolt;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class lighBolt : MonoBehaviour
{
    public GameObject player,boss,fightArea;
    // Start is called before the first frame update
    Vector3 decreaseVal, increaseVal;
    public SpriteRenderer rend, playerRend;
    private float cooldownBolt;
    public float expAreaX, expAreaY;
    private bool isInArea, isInAreaP;
    private float healthBoss;
   public bool canCreatable;
    GameObject[] bolts;
    bool isCompleted;
    Color c;
    void Start()
    {
        cooldownBolt = 0;
        isCompleted = true;
      

    }

    // Update is called once per frame
    void Update()
    {
        if(boss != null)
        healthBoss = boss.GetComponent<bossHealthSystem>().bossHealth;

        isInArea = fightArea.GetComponent<startBossFight>().startLightB;
        isInAreaP = fightArea.GetComponent<startBossFight>().startBossF;
        // canLDamage = gameObject.transform.GetChild(2).gameObject.GetComponent<lightBoltExplosion>().canLightDamage;

        if (isInAreaP && healthBoss <= 100 && isCompleted)
        {
            isCompleted = false;
            StartCoroutine(chasePlayer());
        }

    }
    private IEnumerator chasePlayer()
    {

        GetComponent<LightningBoltScript>().EndPosition.y = 0;
        yield return new WaitForSeconds(2);
        StartFadingOutP();
        yield return new WaitForSeconds(0.90f);
        if(boss!=null)
        boss.gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
        gameObject.transform.position = new Vector3(player.transform.position.x + Random.Range(-1.5f, 1.5f), gameObject.transform.position.y, 0);
        if (!isInArea)
        {
            float objectPositionY = gameObject.transform.position.y;
            float objectPositionX = gameObject.transform.position.x;
            float areaCenter = GameObject.Find("FightArea").GetComponent<BoxCollider2D>().bounds.center.x;
            if (areaCenter - objectPositionX > 0)
            {

                gameObject.transform.position = new Vector3(objectPositionX + Random.Range(3, 3.5f), objectPositionY, 0);

            }
            if (areaCenter - objectPositionX < 0)
            {
                gameObject.transform.position = new Vector3(objectPositionX - Random.Range(3, 3.5f), objectPositionY, 0);

            }
        }
        canCreatable = true;

        StartFadingIn();

        yield return new WaitForSeconds(3);
        StartFadingOut();
        yield return new WaitForSeconds(1.25f);
       
        while (GetComponent<LightningBoltScript>().EndPosition.y != -10)
        {
            GetComponent<LightningBoltScript>().EndPosition.y -= 2.5f;
        }
        yield return new WaitForSeconds(0.1f);
        //Collider2D playerToDamage = Physics2D.OverlapBox(gameObject.transform.GetChild(2).position, new Vector2(1.741548f, 8), 0);
        GetComponent<BoxCollider2D>().enabled = true;
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        yield return new WaitForSeconds(5f);
        GetComponent<BoxCollider2D>().enabled = false;
        while (GetComponent<LightningBoltScript>().EndPosition.y != 0)
        {
            GetComponent<LightningBoltScript>().EndPosition.y += 2f;
        }
        yield return new WaitForSeconds(2f);
        if(boss!=null)
        boss.gameObject.SetActive(true);
        StartFadingInP();
        isCompleted = true;
    }

    IEnumerator FadeOut(SpriteRenderer sr)
    {
        for (float f = 1.0f; f >= -0.05f; f -= 0.05f)
        {
            if(boss != null)
            {
                c = sr.material.color;
                c.a = f;
                sr.material.color = c;
                yield return new WaitForSeconds(0.05f);
            }
            
        }

    }
    public void StartFadingOut()
    {
        StartCoroutine(FadeOut(rend));
    }
    public void StartFadingOutP()
    {
        StartCoroutine(FadeOut(playerRend));
    }
    IEnumerator FadeIn(SpriteRenderer sr)
    {
        for (float f = 0.05f; f <= 1f; f += 0.05f)
        {
            if(boss != null)
            {
                c = sr.material.color;
                c.a = f;
                sr.material.color = c;
                yield return new WaitForSeconds(0.05f);
            }
          
        }

    }
    public void StartFadingIn()
    {
        StartCoroutine(FadeIn(rend));
    }
    public void StartFadingInP()
    {
        StartCoroutine(FadeIn(playerRend));
    }
    public IEnumerator throwCharacter(float horizontalPush, float verticalPush)
    {
        GameObject.Find("Kinder").GetComponent<BasicMech>().enabled = false;
        //Debug.Log("Kinder fýrlatýldý");
        GameObject.Find("Kinder").GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(horizontalPush, verticalPush));
        yield return new WaitForSeconds(0.5f);
        GameObject.Find("Kinder").GetComponent<BasicMech>().enabled = true;

    }
    public void startThrow()
    {

        if (gameObject.transform.GetChild(2).position.x - player.transform.position.x > 0)
        {
            StartCoroutine(throwCharacter(-10000 * Time.deltaTime, 5000f * Time.deltaTime));
        }
        if (gameObject.transform.GetChild(2).position.x - player.transform.position.x < 0)
        {
            StartCoroutine(throwCharacter(10000 * Time.deltaTime, 5000f * Time.deltaTime));

        }
        else if (gameObject.transform.GetChild(2).position.x - player.transform.position.x == 0)
            StartCoroutine(throwCharacter(0, 5000f * Time.deltaTime));
    }

}