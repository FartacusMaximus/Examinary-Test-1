using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMovement : MonoBehaviour
{
    //The ships speed turning right.
    public float baseRotationSpeed;
    //The ships speed turning left
    float leftRotationSpeed;
    //Player assigned ship speed
    public float baseSpeed;
    //Current ship speed
    float forwardSpeed;
    //The ship variable
    public SpriteRenderer shipRenderer;
    //a timer for time spent in game
    public int timer;
    
    
    // Use this for initialization
    void Start()
    {
        //Sets the current ship speed to the player assigned ship speed
        forwardSpeed = baseSpeed;
        leftRotationSpeed = baseRotationSpeed/2;
    }

    // Update is called once per frame
    void Update()
    {
        //This makes the ship go forward based on given speed, in real time
        transform.Translate(forwardSpeed * Time.deltaTime, 0, 0);

        //Makes it so when you press/hold down the "A" key the ship turn left, also turns the ship green       
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, leftRotationSpeed * Time.deltaTime);
            shipRenderer.color = new Color(0f,1f,0f,1f);
        }
        //Makes it so when you press/hold down the "D" key the ship turn right, also turns the ship blue
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -baseRotationSpeed * Time.deltaTime);
            shipRenderer.color = new Color(0f,0f,1f,1f);
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
    }
}
