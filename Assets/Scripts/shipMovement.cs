using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMovement : MonoBehaviour
{
    //The ships speed turning right.
    public float baseRotationSpeed;
    //The ships speed turning left
    float leftRotationSpeed;
    //How much slower the ship turning left is than the ship turning right
    [Range (0.1f,1f)]
    public float leftSlowerRatio;
    //assigned ship speed
    public float baseSpeed;
    //Current ship speed
    float forwardSpeed;
    //a timer for time spent in game
    int timer;
    //The current location of the ship
    public Transform shipLocation;
    //Give the player the choice if they want random speed or not
    public bool randomShipSpeed;
    //Gives the player the choice if they want a random start location or not
    public bool randomStartPosition;
    // Use this for initialization
    void Start()
    {

        //Sets the left rotation speed to be slower which is based on the leftSlowerRatio
        leftRotationSpeed = baseRotationSpeed*leftSlowerRatio;
        //Sets the timer to 1
        timer = 1;
        //Gives the ship a random start position within view if randomStartPosition is enablaled
        shipLocation.position = new Vector3(Random.Range(-8f, 8f), Random.Range(4.5f,-4.5f));
        //Makes it so that if the player enabled random speed it makes the ship start speed random
        if (randomShipSpeed == true)
        {
        baseSpeed = Random.Range(1, 11);
        }
        //Sets the current ship speed to the player assigned ship speed
        forwardSpeed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //This makes the ship go forward based on given speed, in real time
        transform.Translate(forwardSpeed * Time.deltaTime, 0, 0);

        //Makes it so when you press/hold down the "A" key the ship turn left,
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, leftRotationSpeed * Time.deltaTime);
        }
        //Makes it so when you press/hold down the "D" key the ship turn right, 
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -baseRotationSpeed * Time.deltaTime);
        }
        //Makes it so when you press/hold down the "S" key the current ship speed halfs
        if (Input.GetKey(KeyCode.S))
        {
            forwardSpeed = baseSpeed / 2;
            
        }
        //When the "S"key is up it sets the current ship speed back to the player assigned speed
        if (Input.GetKeyUp(KeyCode.S))
        {
            forwardSpeed = baseSpeed;
        }

        //Prints the time spent in game each second.
        //it does this by checking if the time spent in game is equal to the timer variable
        //If it is then it prints the value of the timer and adds 1 so that this will execute again in the next second.
        if (Time.fixedTime == timer)
        {
            print("Timer: " + timer);
            timer = timer + 1;
        }

        //makes it so when the ship comes to a position that is of screen it warps to the other side so that it goes into view again
        //this is done for both the x position and y position
        if (transform.position.x > 10.5 || transform.position.x <-10.5)
        {
            shipLocation.position = new Vector3 (shipLocation.position.x * -1, shipLocation.position.y);
        }
        if (transform.position.y > 6.5 || transform.position.y < -6.5)
        {
            shipLocation.position = new Vector3(shipLocation.position.x , shipLocation.position.y * -1);
        }

    }
}
