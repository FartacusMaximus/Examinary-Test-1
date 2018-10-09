using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour
{
    //The ship variable that allows modification of the sprite
    public SpriteRenderer shipRenderer;
    //Decides if the colorTransparancy should increase or decrease
    bool colorPulse;
    //Changes the transparancy of the ship
    public float colorTransparancy;
    //Variable for the ships rgb Value
    float red;
    float green;
    float blue;
    // Use this for initialization
    void Start()
    {
        //Sets a starting value for the transparancy of the ship
        colorTransparancy = 1;
        //Makes it so that the ships transparancy will decrease every frame until the transparancy value reaches 0.5
        colorPulse = true;
        red = 1;
        green = 1;
        blue = 1;
    }

    // Update is called once per frame
    void Update()
    {   
        //Sets the ships colour to the specified rgba value 
        shipRenderer.color = new Color(red, green, blue, colorTransparancy);
        //if colorPulse is active the ships transparancy will decrease by 0.1 each frame util the transparancy value reaches 0.5
        //upon reaching a transparancy value of 0.5 it will set colorPulse to false making the colorTransparancy value increase util it reaches 1.0 or higher
        if (colorPulse == true)
        {
            colorTransparancy = colorTransparancy - 0.01f;
            if (colorTransparancy <= 0.5)
            {
                colorPulse = false;
            }
        }
        //If colorPulse is set to false the colorTransparancy will start to increase by 0.1 each  frame util it reaches 1.0 or higher
        //Upon the colorTransparancy value reaching 1.0 it will set color pulse to false and the making the colorTransparancy decrease again util it reaches 0.5
        if (colorPulse == false)
        {
            colorTransparancy = colorTransparancy + 0.1f;
            if (colorTransparancy >= 1)
            {
                colorPulse = true;
            }
        }
        //Makes it so when you press/hold down the "A" key the ship turns green 
        //also gives a value to the rgb variables
        if (Input.GetKey(KeyCode.A))
        {
            red = 0;
            green = 1;
            blue = 0;
            //shipRenderer.color = new Color(red, green, blue, colorTransparancy);
        }
        //Makes it so when you press/hold down the "D" key the ship turns blue
        if (Input.GetKey(KeyCode.D))
        {
            red = 0;
            green = 0;
            blue = 1;
            //shipRenderer.color = new Color(red, green, blue, colorTransparancy);
        }
        // Makes it so that when you press the "Space" key the ship changes into a random colour
        if (Input.GetKeyDown(KeyCode.Space))
        {
            red = Random.Range(0f, 1f);
            green = Random.Range(0f, 1f);
            blue = Random.Range(0f, 1f);
            //shipRenderer.color = new Color(red, green, blue, colorTransparancy);
        }
        //bröther where är thä lööps?
    }
}
