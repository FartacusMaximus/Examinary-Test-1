using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour
{
    //The ship variable that allows modification of the sprite
    public SpriteRenderer shipRenderer;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Makes it so when you press/hold down the "A" key the ship turns green       
        if (Input.GetKey(KeyCode.A))
        {
            shipRenderer.color = new Color(0f, 1f, 0f, 1f);
        }
        //Makes it so when you press/hold down the "D" key the ship turns blue
        if (Input.GetKey(KeyCode.D))
        {
            shipRenderer.color = new Color(0f, 0f, 1f, 1f);
        }
        // Makes it so that when you press the "Space" key the ship changes into a random colour
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shipRenderer.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
        }
    }
}
