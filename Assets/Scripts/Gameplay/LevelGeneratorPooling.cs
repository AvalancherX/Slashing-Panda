using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneratorPooling : MonoBehaviour
{
    [SerializeField] private GameObject groundPrefab, treePrefab;
    [SerializeField] private List<GameObject> treeList = new List<GameObject>();
    private List<GameObject> GroundList = new List<GameObject>();

    [SerializeField] private float groundYPos = -6f, treeYPos = -.18f;
    [SerializeField] private float groundXDistance = 17.85f, treeXDistance = 41f;
    private float lastGroundPos, lastTreePos;
    [SerializeField] private float levelGenerateWaitTime = 5f;
    private float waitTime;

    private void Start()
    {
        GenerateInitialLevel();
        waitTime = Time.time + levelGenerateWaitTime;

    }

    private void Update()
    {
        CheckForLevel();
    }

    private void CheckForLevel()
    {
        if(Time.time > waitTime)
        {
            EnableNewGrounds();
            EnableNewTrees();
            waitTime = Time.time + levelGenerateWaitTime;
        }
    }

    private void GenerateInitialLevel()
    {
        Vector3 groundPos = Vector3.zero;
        GameObject ground;

        for(int i = 0; i < 10; i++)
        {
            groundPos = new Vector3(lastGroundPos, groundYPos, 0f);
            ground = Instantiate(groundPrefab, groundPos, Quaternion.identity, transform);
            GroundList.Add(ground);
            lastGroundPos += groundXDistance;
        }

        Vector3 treePos = Vector3.zero;
        GameObject tree;

        for(int i = 0;i < 5; i++)
        {
            treePos = new Vector3(lastTreePos, treeYPos, 0f);
            tree = Instantiate(treePrefab, treePos, Quaternion.identity, transform);    
            treeList.Add(tree);
            lastTreePos += treeXDistance;
        }
    }

    private void EnableNewGrounds()
    {
        Vector3 groundPos = Vector3.zero;
        foreach(GameObject ground in GroundList)
        {
            if (!ground.activeInHierarchy)
            {
                groundPos = new Vector3(lastGroundPos, groundYPos, 0f);
                ground.transform.position = groundPos;
                ground.SetActive(true);
                lastGroundPos += groundXDistance;
            }
        }
    }

    private void EnableNewTrees()
    {
        Vector3 treePos = Vector3.zero;
        foreach (GameObject tree in treeList)
        {
            if (!tree.activeInHierarchy)
            {
                treePos = new Vector3(lastTreePos, treeYPos, 0f);
                tree.transform.position = treePos;
                tree.SetActive(true);
                lastTreePos += treeXDistance;
            }
        }
    }
}
