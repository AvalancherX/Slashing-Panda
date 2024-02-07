using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.GROUND_TAG)  || collision.CompareTag(TagManager.TREE1_TAG) || collision.CompareTag(TagManager.TREE2_TAG))
        {
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}
