using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float offsetX = -6f;

    private Transform playerPos;
    private Vector3 tempPos;

    private void Awake()
    {
        FindPlayerReference();
    }
    
    void FindPlayerReference()
    {
        playerPos = GameObject.FindWithTag(TagManager.PLAYER_TAG).transform;
    }

    private void FollowPlayer()
    {
        if(!playerPos)
            return;
        
        tempPos = transform.position;
        tempPos.x = playerPos.position.x - offsetX;
        transform.position = tempPos;   
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        FollowPlayer();
    }
}
