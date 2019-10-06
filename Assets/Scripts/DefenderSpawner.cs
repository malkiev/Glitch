using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    void OnMouseDown()
    {
        Debug.Log("mouse clicked");

        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="defenderToSelect"></param>
    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);

        return SnapToGrid(worldPos);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rawWorldPos"></param>
    /// <returns></returns>
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        int newX = Mathf.RoundToInt(rawWorldPos.x);
        int newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 gridPos)
    {
        Defender newDefender = Instantiate(defender, gridPos, Quaternion.identity) as Defender;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarsDisplay>();
        int defenderCost = defender.GetStarCost();

        //if we have enough stars
        if (starDisplay.HaveEnoughStars(defenderCost) )
        {
            //spawn defender
            SpawnDefender(gridPos);

            //spend stars
            starDisplay.SpendStars(defenderCost);
        }
        
    }


}
