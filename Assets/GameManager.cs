using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    static int PlayerScore01 = 0;
    static int PlayerScore02 = 0;

    public GUISkin theSkin;
    public Transform theBall;



    private void Start()
    {
        theBall = GameObject.Find("Ball").transform;
    }
    public static void Score(string wallName)
    {
        if (wallName == "rightWall")
        {
            PlayerScore01 += 1;
        }
        else
        {
            PlayerScore02 += 1;
        }
    }

    
    void OnGUI()
    {
        GUI.skin = theSkin;
        GUI.Label(new Rect(Screen.width / 2 - 150-18, 25, 100, 100), "" + PlayerScore01);
        GUI.Label(new Rect(Screen.width / 2 + 150-18, 25, 100, 100), "" + PlayerScore02);

        if (GUI.Button(new Rect(Screen.width /2-121/2, 35, 121, 53), "RESET"))
        {
            PlayerScore01 = 0;
            PlayerScore02 = 0;
            theBall.gameObject.SendMessage("ResetBall");
        }
    }
}