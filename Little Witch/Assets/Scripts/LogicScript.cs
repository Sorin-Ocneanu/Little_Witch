using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    private int levelStars;
    public Text score;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))  //If you press R
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Load the current scene
        } 
    }

    public void addStar(int value)
    {
        levelStars = levelStars + value;
        score.text = Convert.ToString(levelStars);
    }
    public int getStars()
    {
        return levelStars;
    }
}
