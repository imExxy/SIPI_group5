using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour {
    public float Speed;
    public GameObject nodeNext;
    public GameObject fruit_t1;
    public GameObject fruit_t2;
    public GameObject fruit_t3;
    public GameObject scoreCounter;
    public int nodeDist;
    public AudioSource Chomp;
    private Vector3 Direction = new Vector3(1, 0, 0); //might be removable idk
    private List<Vector3> storedPositions; //for precise following
    private int upperRandRange;
    void Start() {
        Application.targetFrameRate = 120;
        storedPositions = new List<Vector3>();
        //throwing the next node far away so it doesnt hit the head upon start
        //yet it shouldnt hit the head cuz i tagged it "Safe" instead
        Vector3 start = new Vector3(1000, 10000, 10000);
        nodeNext = Instantiate(nodeNext, start, transform.rotation);
        nodeNext.tag = "Safe";
        nodeNext.transform.parent = transform.parent;
    }

    void Update() {
        //movement
        transform.Translate(Direction * Time.deltaTime * Speed);
        //following
        storedPositions.Add(transform.position);
        if(storedPositions.Count > nodeDist){
            nodeNext.transform.position = storedPositions[0];
            storedPositions.RemoveAt(0);
        }
        //controls
        if (Input.GetKeyDown(KeyCode.A)){
            transform.Rotate(0, -90, 0);
        }
        if (Input.GetKeyDown(KeyCode.D)){
            transform.Rotate(0, 90, 0);
        }
    }

    void OnTriggerEnter(Collider other){
        Chomp.Play(); 
        if(other.tag == "Fruit"){
            transform.GetComponentInParent<Length>().len++;
            // scoreCounter.GetComponent<Score>().changeScore(transform.GetComponentInParent<Length>().len-2); old
            int tempScore = scoreCounter.GetComponent<Score>().score;
            int toAdd = other.GetComponent<Fruit>().reward;
            scoreCounter.GetComponent<Score>().changeScore(tempScore + toAdd);
            Destroy(other.gameObject);
            transform.GetComponentInParent<Length>().spawnNode();
            Vector3 myVector = new Vector3(Random.Range(-10.0f, 10.0f), 1, Random.Range(-10.0f, 10.0f));
            if((tempScore + toAdd) < 20)
            {
                upperRandRange = 1;
            }
            if ((tempScore + toAdd) >= 20 && (tempScore + toAdd) < 50)
            {
                upperRandRange = 2;
            }
            if((tempScore + toAdd) >= 50)
            {
                upperRandRange = 3;
            }
            int newFruit = Random.Range(1, (upperRandRange + 1));
            if(newFruit == 1)
            {
                Instantiate(fruit_t1, myVector, transform.rotation);
            }
            if (newFruit == 2)
            {
                Instantiate(fruit_t2, myVector, transform.rotation);
            }
            if (newFruit == 3)
            {
                Instantiate(fruit_t3, myVector, transform.rotation);
            }
            //Instantiate(fruit_t1, myVector, transform.rotation);
        }
        if(other.tag == "Obstacle"){
            scoreCounter.GetComponent<Score>().gameOver();
            Destroy(this);
        }
    }
}
