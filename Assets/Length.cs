using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Length : MonoBehaviour {
    public int len = 2;
    /*void Update() {
        Debug.Log(len);
    }*/
    public void spawnNode(){
        transform.GetChild(len-2).GetComponent<SpawnNode>().spawnNode();
    }
}
