using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacle : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 300f;
    private float zAngle;
    private void Start()
    {
        rotateSpeed = Random.Range(300, 400);
        if(Random.Range(0,2) > 0)
        {
            rotateSpeed *= -1;
        }
    }
    void Update()
    {
        zAngle += Time.deltaTime * rotateSpeed;
        transform.rotation = Quaternion.AngleAxis(zAngle, Vector3.forward);
    }
}
