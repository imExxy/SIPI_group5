using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour{
    public GameObject snake;
    public Vector3 offset;
    void Update() {
        //making the camera always stay above the snake
        transform.position = snake.transform.position + offset;
    }
}
