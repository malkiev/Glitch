﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSlider : MonoBehaviour
{
    [Tooltip("Level timer in seconds")]
    [SerializeField] float levelTime = 10;
    bool triggeredLevelFinished = false;

    private LevelController LevelController;

    // Start is called before the first frame update
    void Start()
    {
        this.LevelController = FindObjectOfType<LevelController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished)
            return;

        GetComponent<Slider>().value = (Time.timeSinceLevelLoad / levelTime);

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if(timerFinished)
        {
            this.LevelController.TimerExpired();
            triggeredLevelFinished = true;
        }
    }
}
