using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraChange : MonoBehaviour {

    public Dropdown dropdown;
    public GameObject mainCamera, topCamera, sideCamera, replayCamera;
    Vector3 mainCamDefPos;
    Vector3 topCamDefPos;
    Vector3 sideCamDefPos;
    Vector3 replayCamDefPos;

    void Start()
    {
        mainCamDefPos = mainCamera.transform.position;
        topCamDefPos = topCamera.transform.position;
        sideCamDefPos = sideCamera.transform.position;
        replayCamDefPos = replayCamera.transform.position;

    }
    public void Dropdown_IndexChanged(int index)
    {
        if (index == 0)
        {
            mainCamera.SetActive(true);
            mainCamera.transform.position = mainCamDefPos;
            topCamera.SetActive(false);
            sideCamera.SetActive(false);
            replayCamera.SetActive(false);
        }
        else if (index == 1)
        {
            topCamera.SetActive(true);
            topCamera.transform.position = topCamDefPos;
            mainCamera.SetActive(false);
            sideCamera.SetActive(false);
            replayCamera.SetActive(false);
        }
        else if (index == 2)
        {
            sideCamera.SetActive(true);
            sideCamera.transform.position = sideCamDefPos;
            mainCamera.SetActive(false);
            topCamera.SetActive(false);
            replayCamera.SetActive(false);
        }
        else if (index == 3)
        {
            sideCamera.SetActive(false);
            mainCamera.SetActive(false);
            topCamera.SetActive(false);
            replayCamera.transform.position = replayCamDefPos;
        }
    }
}
