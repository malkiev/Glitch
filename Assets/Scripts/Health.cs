using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    public void DealDamage(float damage)
    {
        Debug.Log($"Deal damage [{damage}]");
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVFX();

            LevelController levelController = FindObjectOfType<LevelController>();

            Destroy(gameObject);
        }
    }

    public float GetHealth()
    {
        return health;
    }

    /// <summary>
    /// 
    /// </summary>
    private void TriggerDeathVFX()
    {
        if (!deathVFX)
        { return; }

        GameObject deathInstance = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathInstance, 1f);
    }

}
