using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class witcherMovement : MonoBehaviour
{
    private bool canPassFadeIn, canPassFadeOut;
    private int count;
    [SerializeField] private float waitTime;
    [SerializeField] private float ccRange;
    [SerializeField] private float ccDur;
    private Animator anim;
    private Vector2 eyePosition;
    public bool isFlameSeqComplete;
    public bool isFlameSeqCompletePlayer;
    public bool isCCSeqCompletePlayer;
    public bool isCCSeqComplete;
    public bool isHealSeqComplete;
    public float yPositionAoe;
    public float warnObjYPos;
    [SerializeField] GameObject[] anims;
    [SerializeField] private GameObject mainCharacter;
    [SerializeField] private GameObject levelManage;
    [SerializeField] private GameObject warningObject;
    [SerializeField] private GameObject dangerousUI;
    [SerializeField] private GameObject[] stunnedUI;
    [SerializeField] private float maxValue, minValue;
    private FadeInFadeOut fd;
    private SpriteRenderer warningObj;
    [Header("HITBOX VALUES")] [SerializeField]
    private float hBoxX;
    [SerializeField]
    private float hBoxY;

    private bool canConAttack;
    private int countCC;
    private bool isCompleted;
    private float RandomValue;
    private void Start()
    {
        fd = levelManage.GetComponent<FadeInFadeOut>();
        warningObj = warningObject.GetComponent<SpriteRenderer>();
        isCompleted = true;
        anim = GetComponent<Animator>();
        RandomValue = 1;
        if (isCompleted)
        { 
            StartCoroutine(FirstForm());
        }

    }

    private void Update()
    {
        /*canConAttack = GetComponent<WitcherScriptControl>().canContinueAttack;
        if (canConAttack&&isCompleted)
        {
            int val = Random.Range(1, 3);
            
            if (val == 1)
            {
                StartCoroutine(FirstForm());
            }
            else if (val==2)
            {
                StartCoroutine(SecondForm());
            }
            else
                StartCoroutine(ThirdForm());

            canConAttack = false;
        }*/
    }


    private void OnDrawGizmos()
    {
        eyePosition = transform.GetChild(0).transform.GetChild(0).transform.position;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.GetChild(0).transform.GetChild(0).transform.position, new Vector3(hBoxX, hBoxY, 1));
        
   
    }
  public IEnumerator FirstForm()
    {
        Vector2 tempVal;
        canPassFadeIn = false;
        canPassFadeOut = false;
        isFlameSeqComplete = false;
        isFlameSeqCompletePlayer = false;
        isCompleted = false;
        anim.SetBool("aoeSpell",true);
        yield return new WaitWhile(() => isFlameSeqCompletePlayer == true);
        anim.SetBool("aoeSpell",false);
        yield return new WaitForSeconds(0.25f);
        tempVal = new Vector2(mainCharacter.transform.position.x, 0);
        warningObj.gameObject.SetActive(true);
        warningObj.transform.position = tempVal + new Vector2(0, warnObjYPos);
        StartCoroutine(fd.FadeIn(warningObj));
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(fd.FadeOut(warningObj));
        yield return new WaitForSeconds(waitTime);
        warningObj.gameObject.SetActive(false);
        anims[0].SetActive(true);
        anims[0].transform.position = tempVal + new Vector2(0, yPositionAoe);
        yield return new WaitWhile(() => isFlameSeqComplete == true);
        yield return new WaitForSeconds(1.5f);
        isCompleted = true;
        StartCoroutine(SecondForm());
    
    }
    IEnumerator SecondForm()
    {
        countCC = 0;
        Vector2 tempVal;
        Vector2 tempMageVal;
        isCCSeqCompletePlayer = false;
        isCompleted = false;
        anim.SetBool("ccSpell",true);
        yield return new WaitWhile(() => isCCSeqCompletePlayer == true);
        anim.SetBool("ccSpell",false);
        yield return new WaitForSeconds(0.25f);
        tempMageVal = gameObject.transform.position;
        yield return new WaitForSeconds(1f);
         for (int i = 0; i < 4; i++)
         {
             
             if (Mathf.Abs(tempMageVal.x - mainCharacter.transform.position.x) < ccRange)
             {
                 dangerousUI.SetActive(true);
                 countCC++;
             
             }
             else
             {
                 dangerousUI.SetActive(false);
                 
             }
           
             yield return new WaitForSeconds(0.5f);
         }
         dangerousUI.SetActive(false);  
        if (countCC >= 4)
        {
            foreach (var variable in stunnedUI)
            {
                variable.SetActive(true);
            }
            mainCharacter.GetComponent<BasicMech>().enabled = false;
            mainCharacter.GetComponent<Rigidbody2D>().velocity =Vector2.zero;
            mainCharacter.GetComponent<Animator>().enabled = false;
        }
        yield return new WaitForSeconds(2f);
        foreach (var variable in stunnedUI)
        {
            variable.SetActive(false);
        }
        mainCharacter.GetComponent<Animator>().enabled = true;
        mainCharacter.GetComponent<BasicMech>().enabled = true;
       
        yield return new WaitForSeconds(1.5f);
        isCompleted = true;
        StartCoroutine(ThirdForm());
     
    }

   IEnumerator ThirdForm()
   {
       isCompleted = false;
       isHealSeqComplete = false;
       anim.SetBool("healthSpell",true);
       Collider2D[] enemiesToHeal = Physics2D.OverlapBoxAll(transform.GetChild(0).transform.GetChild(0).transform.position, new Vector2(hBoxX, hBoxY), 0);
        foreach (var enemies in enemiesToHeal)
        {
            Debug.Log(enemies.gameObject.name);

            if (enemies.CompareTag("Archer"))
                {
                   enemies.gameObject.GetComponent<GoblinHealth>().IncreaseHealth(50);
                                 
                }
            if (enemies.gameObject.name == "Minotaur")
            {
                
                enemies.gameObject.GetComponent<MinotaurHealth>().IncreaseHealth(50);
                                 
            }
              
       

        }
        yield return new WaitWhile(() => isHealSeqComplete== true);
        anim.SetBool("healthSpell",false);
        yield return new WaitForSeconds(1f);
        isCompleted = true;
        StartCoroutine(FirstForm());
     
      
       
    }


    public void setSpellState(bool canUseSpell)
    {
        isFlameSeqCompletePlayer = canUseSpell;
    }
    public void setSpellFinishState(bool canUseFlame)
    {
        isFlameSeqComplete = canUseFlame;
    }

    private void OnAnimatorMove()
    {
        
    }
}
