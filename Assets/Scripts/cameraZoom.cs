using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraZoom : MonoBehaviour
{
    public float startCameraZoom = 5;
    public float currentCameraZoom;
    [Range(0.000001f,1f)]
    public float zoomIncreaseSpeed;
    // Use this for initialization
    void Start()
    {
        currentCameraZoom = startCameraZoom;
    }

    // Update is called once per frame
    void Update()
    {
        currentCameraZoom = currentCameraZoom + (startCameraZoom * zoomIncreaseSpeed) * Time.deltaTime;
        Camera.main.orthographicSize = currentCameraZoom;
    }
}
