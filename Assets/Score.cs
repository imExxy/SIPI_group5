using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * the Score class controls the score counter, loads the game over screen and resets the scene.
 */ 
public class Score : MonoBehaviour {
    public int score;
    public Text scoreCounter; 
    public GameObject gameOverScreen;
    //these might be used later for changing the way camera works upon death
    //bool isGameOver = false;
    //public GameObject cam;
    //private float counter = 1;
    /*!
     * \param[in] sc Score
     * Technically sets the score, so doing stuff like score multipliers might be tricky
     */
    public void changeScore(int sc){
        score = sc; 
        scoreCounter.text = sc.ToString();
    }
    /*!
     * Resets the scene.
     */
    public void resetGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    /*!
     * There's a commented line that could be used in future development.
     */ 
    public void gameOver(){
        gameOverScreen.SetActive(true);
        //isGameOver = true;
    }
    //this might be used later for changing the way camera works upon death
    /*void Update(){
        if(isGameOver){
            Vector3 fly = new Vector3(0f, cam.transform.position.y + 10.0f/counter * Time.deltaTime, 0f);
            cam.transform.position = fly;
            Debug.Log(fly);
            counter++;
        }
    }*/
}
