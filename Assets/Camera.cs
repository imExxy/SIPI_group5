using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour{
    public GameObject snake;
    public Vector3 offset;
    void Update() {
        transform.position = snake.transform.position + offset;
    }
}
