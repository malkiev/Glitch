﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;

    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public void AddStars(int starsToAdd)
    {
        stars += starsToAdd;
        UpdateDisplay();
    }

    public void SpendStars(int starsToSpend)
    {
        if (starsToSpend > stars)
        {
            return;
        }

        stars -= starsToSpend;
        UpdateDisplay();
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }

}
