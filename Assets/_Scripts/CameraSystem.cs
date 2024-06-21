using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSystem : MonoBehaviour
{
    private CinemachineVirtualCamera currentCamera;
    public CinemachineVirtualCamera targetCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeCamera();
        }
    }

    private void ChangeCamera()
    {
        if (GameObject.FindGameObjectWithTag("CurrentCamera").GetComponent<CinemachineVirtualCamera>() != null)
        {
            currentCamera = GameObject.FindGameObjectWithTag("CurrentCamera").GetComponent<CinemachineVirtualCamera>();
        }
        else
        {
            currentCamera = null;
        }

        if (currentCamera != targetCamera || currentCamera == null)
        {
            targetCamera.tag = "CurrentCamera";
            targetCamera.Priority = 100;
            currentCamera.tag = "InactiveCamera";
            currentCamera.Priority = 99;
        }
    }
}
