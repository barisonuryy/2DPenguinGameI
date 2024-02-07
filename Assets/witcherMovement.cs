using System;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private float maxValue, minValue;
    private FadeInFadeOut fd;
    private SpriteRenderer warningObj;
    [Header("HITBOX VALUES")] [SerializeField]
    private float hBoxX;
    [SerializeField]
    private float hBoxY;

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

    }



    private void OnDrawGizmos()
    {
        eyePosition = transform.GetChild(0).transform.GetChild(0).transform.position;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.GetChild(0).transform.GetChild(0).transform.position, new Vector3(hBoxX, hBoxY, 1));
        
   
    }

    void Update()
    {


        if (isCompleted)
        { 
            StartCoroutine(FirstForm());
        }
           
          
          
     
    }

    IEnumerator FirstForm()
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
        yield return new WaitForSeconds(3f);
        isCompleted = true;
        StartCoroutine(SecondForm());
        RandomValue = Random.Range(1, 2);
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
        tempVal = new Vector2(mainCharacter.transform.position.x, 0);
        tempMageVal = gameObject.transform.position;
        yield return new WaitForSeconds(3f);
         for (int i = 0; i < 4; i++)
         {
             if (Mathf.Abs(tempMageVal.x - mainCharacter.transform.position.x) < ccRange)
             {
                 countCC++;
                 Debug.Log(countCC);
             
             }
             yield return new WaitForSeconds(0.5f);
         }
          
        if (countCC >= 4)
        {
            mainCharacter.GetComponent<BasicMech>().enabled = false;
            mainCharacter.GetComponent<Rigidbody2D>().velocity =Vector2.zero;
            mainCharacter.GetComponent<Animator>().enabled = false;
        }
         
        yield return new WaitForSeconds(2f);
        mainCharacter.GetComponent<Animator>().enabled = true;
        mainCharacter.GetComponent<BasicMech>().enabled = true;
       
        yield return new WaitForSeconds(3f);
        isCompleted = true;
        RandomValue = Random.Range(1, 2);
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
