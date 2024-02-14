using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsWithTransition : MonoBehaviour
{
    private Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    
    public void PlayFromJumpToRunning(bool running)
    {
        anim.SetBool(TagManager.RUNNING_ANIMATION_PARAM, running);
    }

    public void PlayJump(float velocityY)
    {
        anim.SetFloat(TagManager.JUMP_ANIMATION_PARAM, velocityY);
    }

    public void PlayDoubleJump()
    {
        anim.SetTrigger(TagManager.DOUBLE_JUMP_ANIMATION_PARAM);
    }

    public void PlayAttack() {
        anim.SetTrigger(TagManager.ATTACK_ANIMATION_PARAM);
    }

    public void PlayJumpAttack() 
    {
        anim.SetTrigger(TagManager.JUMP_ATTACK_ANIMATION_PARAM) ;
    }
}
