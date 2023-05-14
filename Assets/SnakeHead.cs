using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour {
    public float Speed;
    public GameObject nodeNext;
    public GameObject Fruit;
    public int nodeDist;
    private Vector3 Direction = new Vector3(1, 0, 0);
    private List<Vector3> storedPositions;
    void Start() {
        Application.targetFrameRate = 120;
        storedPositions = new List<Vector3>();
        Vector3 start = new Vector3(1000, 10000, 10000);
        nodeNext = Instantiate(nodeNext, start, transform.rotation);
        nodeNext.tag = "Safe";
        nodeNext.transform.parent = transform.parent;
    }

    void Update() {
        transform.Translate(Direction * Time.deltaTime * Speed);
        storedPositions.Add(transform.position);
        if(storedPositions.Count > nodeDist){
            nodeNext.transform.position = storedPositions[0];
            storedPositions.RemoveAt(0);
        }
        if (Input.GetKeyDown(KeyCode.A)){
            transform.Rotate(0, -90, 0);
        }
        if (Input.GetKeyDown(KeyCode.D)){
            transform.Rotate(0, 90, 0);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Fruit"){
            transform.GetComponentInParent<Length>().len++;
            Destroy(other.gameObject);
            transform.GetComponentInParent<Length>().spawnNode();
            Vector3 myVector = new Vector3(Random.Range(-10.0f, 10.0f), 1, Random.Range(-10.0f, 10.0f));
            Instantiate(Fruit, myVector, transform.rotation);
        }
        if(other.tag == "Tail"){
            Destroy(this);
            Debug.Log("AAAAA");
        }
    }
}
