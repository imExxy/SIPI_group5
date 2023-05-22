using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNode : MonoBehaviour {
    public GameObject nextNode;
    public bool hasSpawned = false; //for spawning new nodes
    public int nodeDist = 12; //how many positions we store for precise following
    private List<Vector3> storedPositions; //for precise following

    void Start() {
        storedPositions = new List<Vector3>();
    }
    /**
     * SpawnNode.Update is responsible for storing and updating positions for precise following.
     */
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
    /*!
     * Spawns the next node (duh)
     */
    public void spawnNode(){
        nextNode = Instantiate(nextNode, transform.position, transform.rotation);
        nextNode.transform.parent = transform.parent;
        nextNode.name = "body";
        nextNode.tag = "Obstacle";
        hasSpawned = true;
    }
}
