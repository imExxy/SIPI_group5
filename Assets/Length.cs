using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * The Length class is used for storing the length of the snake.
 * This is useful for showing the score and accessing different nodes of the snake;
 */
public class Length : MonoBehaviour {
    public int len = 2;
    public void spawnNode(){
        //(len-2) always points to the last piece of the tail
        transform.GetChild(len-2).GetComponent<SpawnNode>().spawnNode();
    }
}
