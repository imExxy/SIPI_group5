using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {
    public int score;
    public Text scoreCounter; 
    public GameObject gameOverScreen;
    //bool isGameOver = false;
    //public GameObject cam;
    //private float counter = 1;

    public void changeScore(int sc){
        score = sc; 
        scoreCounter.text = sc.ToString();
    }

    public void resetGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver(){
        gameOverScreen.SetActive(true);
        //isGameOver = true;
    }
    /*void Update(){
        if(isGameOver){
            Vector3 fly = new Vector3(0f, cam.transform.position.y + 10.0f/counter * Time.deltaTime, 0f);
            cam.transform.position = fly;
            Debug.Log(fly);
            counter++;
        }
    }*/
}
