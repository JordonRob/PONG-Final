using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2D;
    static int CountDown = 3;
    bool Need = true;
    private GUISkin skin;

    // Use this for initialization
    void Start()
    {
        //Invoke ("GoBall", 2);
        StartCoroutine(Count());
    }
    void Update()
    {
        float xVel = rb2D.velocity.x;
        //Debug.Log("Velocity" + xVel);
        if (xVel < 18f && xVel > -18 && xVel != 0)
        {
            if (xVel > 0)
            {
                rb2D.velocity = new Vector2(20, rb2D.velocity.y);
            }
            else
            {
                rb2D.velocity = new Vector2(-20, rb2D.velocity.y);
            }
        }
    }
    IEnumerator Count()
    {
        for (int i = 3; i > 0; i--)
        {
            yield return new WaitForSeconds(1);
            CountDown--;
        }
        Need = false;
        GoBall();
    }

    void OnGUI()
    {
        GUI.skin = skin;
        if (Need == true)
        {
            GUI.Label(new Rect(Screen.width / 2 - 12, Screen.height / 2 + 30, 200, 200), "" + CountDown);
        }
    }

    public void ResetBall()
    {
        rb2D.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
        Invoke("GoBall", 1);
    }

    void GoBall()
    {
        rb2D = GetComponent<Rigidbody2D>();
        int randomNumber = UnityEngine.Random.Range(0, 3); 

        if (randomNumber == 0) 
        {
            rb2D.AddForce(new Vector2(80, 10) * speed * Time.deltaTime); 
        }
        else
        {
            rb2D.AddForce(new Vector2(-80, -10) * speed * Time.deltaTime); 
        }
    }

    void OnCollisionEnter2D(Collision2D colInfo)
    {
        if (colInfo.collider.tag == "Player") 
        {
            float velY = rb2D.velocity.y; 
            rb2D.velocity = new Vector2(rb2D.velocity.x, velY / 3 + colInfo.collider.GetComponent<Rigidbody2D>().velocity.y / 4);
          

        }
    }
}