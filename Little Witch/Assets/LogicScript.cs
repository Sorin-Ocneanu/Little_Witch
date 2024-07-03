using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    private int levelStars;

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
        string message = Convert.ToString(levelStars);
        Debug.Log("stars "+message);
    }
    public int getStars()
    {
        return levelStars;
    }
}
