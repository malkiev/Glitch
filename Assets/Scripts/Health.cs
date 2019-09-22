using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void DealDamage(float damage)
    {
        Debug.Log($"Deal damage [{damage}]");
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
