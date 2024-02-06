using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackSequenceforFlame : StateMachineBehaviour
{
   


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
{
    GameObject.Find("MonD_01").GetComponent<witcherMovement>().setSpellFinishState(true);
    animator.gameObject.SetActive(false);
}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
