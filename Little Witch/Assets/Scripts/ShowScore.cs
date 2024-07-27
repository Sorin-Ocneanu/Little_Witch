using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    
    private int levelStars;
    private Text score;
    
    // Start is called before the first frame update
    void Start()
    {
            score = GetComponent<Text>();
    }

    public void addStar(int value)
    {
        levelStars = levelStars + value;
        score.text = Convert.ToString(levelStars);
    }
}
