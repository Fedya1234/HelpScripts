using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMainCamera : MonoBehaviour
{
    Transform mainCamera;
    private void Start()
    {
        mainCamera = FindObjectOfType<Camera>().transform;
    }
    void LateUpdate()
    {

        transform.LookAt(mainCamera.transform);
    }
}
