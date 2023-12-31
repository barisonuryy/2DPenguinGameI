using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_set : MonoBehaviour
{
    public GameObject uiControl;
    public GameObject healthControl;
    public float mana,maxMana;
    bool isIn;
    public bool isInarmor,armorControll;
    public float armorcont;
    public float armor;
    public bool isInIncrease;
    // Start is called before the first frame update
    void Start()
    {
        mana = 50;
        armor = 5;
        isInarmor = false;
        isIn = false;
        armorControll = false;
        isInIncrease = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(armorControll)
        armorControl();
        if (!isIn)
        {
            isIn = true;
            StartCoroutine(updateMana());
        }
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(!isInarmor&&mana>=10)
            {
                isInarmor = true;
                mana -= 10;
                StartCoroutine(getArmor());
            }
        }
        if (gameObject.GetComponent<BasicMech>().dashControl)
        {
            uiControl.transform.GetChild(uiControl.transform.childCount - 3).gameObject.SetActive(true);
            mana -= 10;
        }
        if (mana < 10)
        {
            uiControl.transform.GetChild(uiControl.transform.childCount - 2).gameObject.SetActive(true);
            uiControl.transform.GetChild(uiControl.transform.childCount - 3).gameObject.SetActive(true);
            uiControl.transform.GetChild(uiControl.transform.childCount - 1).gameObject.SetActive(true);
        }

        if(!isInIncrease&&mana >= 10)
        {
            uiControl.transform.GetChild(uiControl.transform.childCount - 1).gameObject.SetActive(false);
        }
        if (!isInarmor && mana >= 10)
        {
            uiControl.transform.GetChild(uiControl.transform.childCount - 2).gameObject.SetActive(false);
        }
        if (gameObject.GetComponent<BasicMech>().canDash && mana >= 10)
        {
            uiControl.transform.GetChild(uiControl.transform.childCount - 3).gameObject.SetActive(false);
        }



        if (Input.GetKeyDown(KeyCode.C) && mana >= 10)
        {
            if (!isInIncrease)
            {
                isInIncrease = true;
                StartCoroutine(increaseAttack());
                mana -= 10;
            }
       
        }

       
    }
    public void armorControl()
    {
        if (gameObject.GetComponent<PlayerHealth>().health <= armorcont-armor)
        {
            uiControl.transform.GetChild(uiControl.transform.childCount - 1).gameObject.SetActive(false);
            gameObject.GetComponent<PlayerHealth>().health = armorcont - armor;
            isInarmor = false;
            armorControll = false;
        }

    }
    private IEnumerator updateMana()
    {
        if (mana < 50)
        {
            mana += 1;
            yield return new WaitForSeconds(0.5f);
        }
        isIn = false;



    }
    private IEnumerator increaseAttack()
    {
        uiControl.transform.GetChild(uiControl.transform.childCount - 1).gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
       
        isInIncrease = false;

    }
    private IEnumerator getArmor()
    {

        
        gameObject.GetComponent<PlayerHealth>().health += armor;
        armorcont = gameObject.GetComponent<PlayerHealth>().health;
        armorControll = true;
        uiControl.transform.GetChild(uiControl.transform.childCount - 2).gameObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        if (isInarmor)
        {
            gameObject.GetComponent<PlayerHealth>().health = armorcont - armor;
            uiControl.transform.GetChild(uiControl.transform.childCount - 2).gameObject.SetActive(false);
        }
        isInarmor = false;
        armorControll = false;
    }
}
