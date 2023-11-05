using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDemo : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetLayerWeight(0, 1);

        anim.SetTrigger("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  
    public void Idle()
    {

        anim.SetTrigger("Idle");
    }

    public void Idle2()
    {

        anim.SetTrigger("Idle2");
    }

    public void Landing()
    {
        anim.SetTrigger("Landing");
    }
    

        public void Idle3()
    {
        anim.SetTrigger("Idle3");
    }

    

    public void Idle4()
    {
        anim.SetTrigger("Idle4");
    }

    public void Idle5()
    {
        anim.SetTrigger("Idle5");
    }

    public void Walk()
    {
        anim.SetTrigger("Walk");
    }

    public void Run()
    {
        anim.SetTrigger("Run");
    }

    public void SpeedRun()
    {
        anim.SetTrigger("SpeedRun");
    }

    public void Punch()
    {
        anim.SetTrigger("Punch");
    }


    public void Jump()
    {
        anim.SetTrigger("Jump");
    }

    

    public void FlyUp()
    {
        anim.SetTrigger("FlyUp");
    }

    public void FlyFront()
    {
        anim.SetTrigger("FlyFront");
    }

    public void FlyBack()
    {
        anim.SetTrigger("FlyBack");
    }



    public void Fall()
    {
        anim.SetTrigger("Fall");
    }

    public void HitFront()
    {
        anim.SetTrigger("HitFront");
    }

    public void HitBack()
    {
        anim.SetTrigger("HitBack");
    }



    public void DieBack()
    {
        anim.SetTrigger("DieBack");
    }

    public void DieFront()
    {
        anim.SetTrigger("DieFront");
    }

    public void Attack1()
    {
        anim.SetTrigger("Attack1");
    }

    public void Attack2()
    {
        anim.SetTrigger("Attack2");
    }

    public void Attack3()
    {
        anim.SetTrigger("Attack3");
    }

    public void AttackSword2()
    {
        anim.SetTrigger("AttackSword2");
    }

    public void Kick()
    {
        anim.SetTrigger("Kick");
    }

    public void IdleLadder()
    {
        anim.SetTrigger("IdleLadder");
    }

    public void ClimbingLadder()
    {
        anim.SetTrigger("ClimbingLadder");
    }

    public void PistolDieBack()
    {
        anim.SetTrigger("PistolDieBack");
    }

    public void PistolDieFront()
    {
        anim.SetTrigger("PistolDieFront");
    }

    public void PistolFlyBack()
    {
        anim.SetTrigger("PistolFlyBack");
    }

    public void PistolFlyFront()
    {
        anim.SetTrigger("PistolFlyFront");
    }

    public void PistolFlyUp()
    {
        anim.SetTrigger("PistolFlyUp");
    }

    public void PistolHitBack()
    {
        anim.SetTrigger("PistolHitBack");
    }

    public void PistolHitFront()
    {
        anim.SetTrigger("PistolHitFront");
    }

    public void PistolIdle()
    {
        anim.SetTrigger("PistolIdle");
    }

    public void PistolJump()
    {
        anim.SetTrigger("PistolJump");
    }

    public void PistolLanding()
    {
        anim.SetTrigger("PistolLanding");
    }

    public void PistolRun()
    {
        anim.SetTrigger("PistolRun");
    }

    public void PistolShoot()
    {
        anim.SetTrigger("PistolShoot");
    }

    public void PistolWalk()
    {
        anim.SetTrigger("PistolWalk");
    }

    public void To4()
    {

        anim.SetTrigger("2To4");
    }
    
    public void Attack()
    {

        anim.SetTrigger("4Attack");
    }

    public void Die()
    {

        anim.SetTrigger("4Die");
    }

    public void FlyBack4()
    {

        anim.SetTrigger("4FlyBack");
    }

    public void FlyFront4()
    {

        anim.SetTrigger("4FlyFront");
    }

    public void HitBack4()
    {

        anim.SetTrigger("4HitBack");
    }

    public void HitFront4()
    {

        anim.SetTrigger("4HitFront");
    }

    public void Idle44()
    {

        anim.SetTrigger("4Idle");
    }

    public void Run4()
    {

        anim.SetTrigger("4Run");
    }

    public void Walk4()
    {

        anim.SetTrigger("4Walk");
    }

    public void To24()
    {

        anim.SetTrigger("4To2");
    }

    public void Jump4()
    {

        anim.SetTrigger("4Jump");
    }

    public void JumpFly4()
    {

        anim.SetTrigger("4JumpFly");
    }

    public void JumpLanding4()
    {

        anim.SetTrigger("4JumpLanding");
    }

}
