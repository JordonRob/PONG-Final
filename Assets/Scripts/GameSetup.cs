using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System.Collections;

public class GameSetup : MonoBehaviour
{
    public Camera mainCam;
    public BoxCollider2D topWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;

    public Transform player01;
    public Transform player02;

   
    void Start()
    {
        topWall.size = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x * 2f, 1f);
        topWall.offset = new Vector2(0f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 0.1f);

        bottomWall.size = topWall.size;
        bottomWall.offset = -topWall.offset;

        leftWall.size = new Vector2(1f, mainCam.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y * 2f);
        leftWall.offset = new Vector2(mainCam.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.1f, 0f);

        rightWall.size = leftWall.size;
        rightWall.offset = -leftWall.offset;

        player01.position.Set(mainCam.ScreenToWorldPoint(new Vector3(75f, 0f, 0f)).x, 0f, 0f);
        player02.position.Set(mainCam.ScreenToWorldPoint(new Vector3(Screen.width - 75f, 0f, 0f)).x, 0f, 0f);

    }
    
    void Update()
    {
    }
}
