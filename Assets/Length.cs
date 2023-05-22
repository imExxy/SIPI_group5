using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Length : MonoBehaviour {
    public int len = 2;
    public void spawnNode(){
        //(len-2) always points to the last piece of the tail
        transform.GetChild(len-2).GetComponent<SpawnNode>().spawnNode();
    }
}
