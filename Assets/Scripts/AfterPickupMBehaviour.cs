using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterPickupMBehaviour : StateMachineBehaviour
{
    ApplyForceBasedOnMousePos playerMov;
    HealthScript hScript;

    CamerasManager manager;

    public GameObject cam;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerMov = GameObject.FindObjectOfType<ApplyForceBasedOnMousePos>();
        hScript = GameObject.FindObjectOfType<HealthScript>();
        
        playerMov.enabled = hScript.enabled = false;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    //manager.DestroyCurrentCamera(0.3f);
    //    //animator.StopPlayback();
    //}

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
