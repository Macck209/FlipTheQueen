using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }
}
