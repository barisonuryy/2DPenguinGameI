using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackSequenceForWitch : StateMachineBehaviour
{

  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
      animator.GetComponent<witcherMovement>().setSpellState(true);
  }

}
