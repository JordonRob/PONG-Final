using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Use this for initialization
    public KeyCode moveUp;
    public KeyCode moveDown;

    public float speed = 10;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveUp))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        }
        else if (Input.GetKey(moveDown))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity  = new Vector2(0, 0);
        }
    }
}
