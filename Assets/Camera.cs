using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
the Camera class is used solely for moving the camera. 
For now it always stays directly above the snake.
*/
public class Camera : MonoBehaviour{
    public GameObject snake;
    public Vector3 offset;
    void Update() {
        //making the camera always stay above the snake
        transform.position = snake.transform.position + offset;
    }
}
