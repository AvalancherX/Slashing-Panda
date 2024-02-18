using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject damageCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAttack()
    {
        anim.SetTrigger(TagManager.ATTACK_TRIGGER_PARAM);
    }

    public void PlayDeath() 
    {
        anim.SetBool(TagManager.DEATH_ANIMATION_PARAM, true);
    }

    private void ActivateDamageCollider()
    {
        damageCollider.SetActive(true);
    }

    private void DeactivateDamageCollider()
    {
        damageCollider.SetActive(false);
    }
}
