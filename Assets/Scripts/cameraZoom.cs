using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraZoom : MonoBehaviour
{
    //The zoom value which the camera starts at
    float startCameraZoom = 5;
    //the zoom value which the camera is currently at
    //this is public so that we can use this variable in other scripts
    public float currentCameraZoom;
    [Range(0.000001f,1f)]
    public float zoomIncreaseSpeed= 0.1f;
    //the speed which the camera will zoom out
    // Use this for initialization
    void Start()
    {
        //Sets the currentCameraZoom to the value of the startCameraZoom
        currentCameraZoom = startCameraZoom;
    }

    // Update is called once per frame
    void Update()
    {
        //this will make it so that the camera will pan out during the course of the game this will be done indepenendtly  of framerate 
        currentCameraZoom = currentCameraZoom + (startCameraZoom * zoomIncreaseSpeed) * Time.deltaTime;
        //sets the main camera size  to the value of currentCameraZoom
        Camera.main.orthographicSize = currentCameraZoom;
    }
}
