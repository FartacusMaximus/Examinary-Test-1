using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    //Current Asteroid speed
    [Range(1,10)]
    public float asteroidbaseSpeed = 5;
    //a Variable which lets us use variables from the cameraZoom script
    public cameraZoom cameraScript;
    //The current location of the asteroid
    public Transform asteroidLocation;
    //This is a variable so that the warp range increases proportionally to the camera zoom
    float warpIncrease;
    //the speed which the asteroids will rotate
    public float asteroidRotationSpeed = 60;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Sets warpIncrease to the value of the currentCameraZoom
        warpIncrease = cameraScript.currentCameraZoom;

        //Makes the asteroids move to the right relative to the world
        transform.Translate(asteroidbaseSpeed * Time.deltaTime, 0, 0, Space.World);
        //rotates the asteroid sprite along the z axis
        transform.Rotate(0, 0, asteroidRotationSpeed*Time.deltaTime);
        //this is the same as the ship warp but with android and the y position of the asteroid is random
        if (transform.position.x > 2.1 * warpIncrease || transform.position.x < -2.1 * warpIncrease)
        {
            asteroidLocation.position = new Vector3(asteroidLocation.position.x * -1, (Random.Range(1.1f,-1.1f)*warpIncrease));
        }
        if (transform.position.y > 1.3 * warpIncrease || transform.position.y < -1.3 * warpIncrease)
        {
            asteroidLocation.position = new Vector3((Random.Range(2,-2)*warpIncrease), asteroidLocation.position.y * -1);
        }
    }
}
