using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNode : MonoBehaviour {
    public GameObject nextNode;
    public bool hasSpawned = false;
    public int nodeDist = 12; 
    private List<Vector3> storedPositions; //for precise following

    void Start() {
        storedPositions = new List<Vector3>();
    }

    void Update() {
        if(hasSpawned){
            storedPositions.Add(transform.position);
            if(storedPositions.Count > nodeDist){
                nextNode.transform.position = storedPositions[0];
                //might need to do this in a loop so we can change nodeDist
                storedPositions.RemoveAt(0); 
            }
        }
    }

    public void spawnNode(){
        nextNode = Instantiate(nextNode, transform.position, transform.rotation);
        nextNode.transform.parent = transform.parent;
        nextNode.name = "body";
        nextNode.tag = "Obstacle";
        hasSpawned = true;
    }
}
