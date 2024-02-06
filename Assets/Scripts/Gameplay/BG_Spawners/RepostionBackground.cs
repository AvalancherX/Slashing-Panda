using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepostionBackground : MonoBehaviour
{
    [SerializeField]
    private GameObject[] backgrounds;

    [SerializeField] private string tag;

    private float highestXPosition;
    private float offsetValue;
    private float newXPosition;
    private Vector3 newPosition;

    private void Awake()
    {
        backgrounds = GameObject.FindGameObjectsWithTag(tag);

        offsetValue = backgrounds[0].GetComponent<BoxCollider2D>().bounds.size.x;
        highestXPosition = backgrounds[0].transform.position.x;

        for(int i = 1; i < backgrounds.Length; i++)
        {
            if (backgrounds[i].transform.position.x > highestXPosition)
            {
                highestXPosition = backgrounds[i].transform.position.x;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(tag))
        {
            newXPosition = highestXPosition + offsetValue;
            highestXPosition = newXPosition;
            newPosition = collision.transform.position;
            newPosition.x = newXPosition;
            collision.transform.position = newPosition;
        }
    }
}
