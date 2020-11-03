using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasManager : MonoBehaviour
{
    public CinemachineVirtualCamera currentCam;

    public CinemachineVirtualCamera lastCam;

    // Start is called before the first frame update
    void Start()
    {
        currentCam = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
        lastCam = currentCam;
    }

    public void SetCamera(CinemachineVirtualCamera newCam)
    {
        lastCam = currentCam;
        currentCam = newCam;
    }

    public void DestroyCurrentCamera(float afterTime)
    {
        if (lastCam != currentCam)
        {
            Destroy(currentCam.gameObject, afterTime);
            currentCam = lastCam;
        }
    }

}
