using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingObstacle : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    private float zAngle;
    [SerializeField] private float minZRotation = -165, maxZRotation = -10;
    private void Start()
    {
        if (Random.Range(0, 2) > 0)
        {
            rotateSpeed *= -1;
        }
    }
    void Update()
    {
        zAngle += Time.deltaTime * rotateSpeed;
        transform.rotation = Quaternion.AngleAxis(zAngle, Vector3.forward);

        if (transform.rotation.z < minZRotation)
        {
            rotateSpeed = Mathf.Abs(rotateSpeed);
        }
        if (transform.rotation.z > maxZRotation)
        {
            rotateSpeed = -Mathf.Abs(rotateSpeed);
        }
    }
}
