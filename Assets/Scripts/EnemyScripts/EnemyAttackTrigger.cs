using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    private EnemyAnimations enemyAnim;

    private void Awake()
    {
        enemyAnim = GetComponentInParent<EnemyAnimations>();
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag(TagManager.PLAYER_TAG))
        {
            enemyAnim.PlayAttack();
        }
    }
}
