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
    //Player assigned ship speed
    public float baseSpeed;
    //Current ship speed
    float forwardSpeed;
    //The ship variable
    public SpriteRenderer shipRenderer;
    //a timer for time spent in game
    int timer;
    public Transform shipLocation;
    
    // Use this for initialization
    void Start()
    {

        //Sets the current ship speed to the player assigned ship speed
        //Sets the timer to 1
        //Sets the left rotation speed to be slower which is based on the leftSlowerRatio
        forwardSpeed = baseSpeed;
        leftRotationSpeed = baseRotationSpeed*leftSlowerRatio;
        timer = 1;
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
        // Makes it so that when you press the "Space" key the ship changes colour
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shipRenderer.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        }
        if (transform.position.x > 10.5 || transform.position.x <-10.5)
        {
            shipLocation.position = new Vector3 (shipLocation.position.x * -1, shipLocation.position.y);
        }
    }
}
