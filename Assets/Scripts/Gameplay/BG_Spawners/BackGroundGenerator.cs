using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundGenerator : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab, tree1Prefab, tree2Prefab;
    [SerializeField] private float groundYPos = -6f, treeYPos = -.18f;
    [SerializeField] private float groundXDistance = 17.85f, treeXDistance = 41.2f;
    private float lastGroundXPos, lastTreesXPos;
    [SerializeField] private float generateLevelWaitTime = 3f;
    private float waitTimer;

    private void Start()
    {
       // StartCoroutine(SpawnLevel()); 
    }

    IEnumerator SpawnLevel()
    {
        while (true)
        {
            GroundGenerator();
            GenerateTrees();
            yield return new WaitForSeconds(generateLevelWaitTime);
        }
    }
    private void Update()
    {
        CheckToSpawnLevelParts();
    }
    private void CheckToSpawnLevelParts()
    {
        if(Time.time > waitTimer)
        {
            GenerateTrees();
            GroundGenerator();
            waitTimer = Time.time + generateLevelWaitTime;
        }
    }
    private void GroundGenerator()
    {
        Vector3 groundPosition = Vector3.zero;

        for (int i = 0; i < 5; i++)
        {
            groundPosition = new Vector3(lastGroundXPos, groundYPos, 0f);
            Instantiate(groundPrefab, groundPosition, Quaternion.identity, transform);
            lastGroundXPos += groundXDistance;
        }
    }

    private void GenerateTrees()
    {
        Vector3 treePosition = Vector3.zero;
        
        for(int i = 0;i < 2; i++)
        {
            treePosition = new Vector3(lastTreesXPos,treeYPos, 0f);
            if (Random.Range(0, 2) > 0)
            {
                Instantiate(tree1Prefab, treePosition, Quaternion.identity, transform);
                Instantiate(tree2Prefab, treePosition, Quaternion.identity, transform);
            }
            else
            {
                Instantiate(tree2Prefab, treePosition, Quaternion.identity, transform);
                Instantiate(tree1Prefab, treePosition, Quaternion.identity, transform);
            }
            lastTreesXPos += treeXDistance;
        }

    }

}
