using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starSitutation : MonoBehaviour
{
    GameObject activableStar;
    GameObject disableStar;
    int score;
    bool passed;
    int index;
    bool dead;
   
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        LevelManage s=GameObject.Find("LevelManager").GetComponent<LevelManage>();
        score= s.score;
        Finish p = GameObject.Find("Finish").GetComponent<Finish>();
        passed=p.passed;
        LevelManage d = GameObject.Find("LevelManager").GetComponent<LevelManage>();
        dead=d.dead;
        StartCoroutine(showStars());
    }
    private IEnumerator showStars()
    {
        
        if (passed)
        {
           
            if (score >= 150&&score<250)
            {
                index = 0;
                defineStar(index, index + 3);
                yield return new WaitForSeconds(1.5f);
                defineStar(index+4,index+1);
                yield return new WaitForSeconds(1.5f);
                defineStar(index+5,index+2);
            }
            else if (score >= 250 && score < 350)
            {
                index = 0;
                for(int i = 0; i < 2; i++)
                {
                    defineStar(index+i,index+i+3);
                    yield return new WaitForSeconds(1.5f);
                }
                    defineStar(index + 5,index+2);
            }
            else if (score >= 350)
            {
                index = 0;
                for(int i = 0; i < 3; i++)
                {
                    defineStar(index+i,index+i+3);
                    yield return new WaitForSeconds(1.5f);
                }
             
            }
        }
        if (dead)
        {

            
            index = 3;
             for (int i = 0; i < 3; i++)
             {
                 defineStar(index + i, index + i - 3);
                 yield return new WaitForSeconds(1f);
             }
           
        }
    }
    private void defineStar(int x,int y)
    {
        activableStar = gameObject.transform.GetChild(x).gameObject;
        activableStar.SetActive(true);
        disableStar= gameObject.transform.GetChild(y).gameObject;
        disableStar.SetActive(false);
    }
    
    
}
