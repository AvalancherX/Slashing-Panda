using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private bool deactivateGameobject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.PLAYER_TAG))
        {
            if(deactivateGameobject)
            {
                gameObject.SetActive(false);
            }
        }
        if(collision.CompareTag(TagManager.ENEMY_TAG) || collision.CompareTag(TagManager.OBSTACLE_TAG))
        {
            Debug.Log("Dealt Damage");
        }
        
    }
}
