﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 4;
    [SerializeField] GameObject winLabel;

    int currentSceneIndex;


    // Start is called before the first frame update
    void Start()
    {
        
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }


    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    IEnumerator WaitForGameOver()
    {
        yield return new WaitForSeconds(timeToWait);
        SceneManager.LoadScene("GameOver");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex+1);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitForGameOver());
    }
}
