using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource attack;
    public AudioSource walk;
    public AudioSource slide;
    public AudioSource jump;
   

    // Update is called once per frame
    void Update()
    {
      

        PlayAttackSFX(); 
        PlayJumpSFX();
        PlaySlideSFX();
        PlayWalkSFX();
    }
    private void PlayAttackSFX()
    {
        BasicMech canSound = GameObject.Find("Kinder").GetComponent<BasicMech>();
        bool attackS = canSound.attack;
        if (attackS)
        {
            
            attack.Play();
        }
    }
    private void PlayWalkSFX()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            walk.Play();
           
        }
       
    }
    private void PlayJumpSFX()
    {
        BasicMech canSound = GameObject.Find("Kinder").GetComponent<BasicMech>();
        bool jumpS = canSound.jump;
        if (jumpS)
        {
            jump.Play();
        }
    }
    private void PlaySlideSFX()
    {
        BasicMech canSound = GameObject.Find("Kinder").GetComponent<BasicMech>();
        bool slideS = canSound.slide;
        if (slideS)
        {
            slide.Play();
        }
    }
}
