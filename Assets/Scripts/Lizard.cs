using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D othercollider)
    {
        GameObject otherObject = othercollider.gameObject;
        Defender defender = otherObject.GetComponent<Defender>();
        if (defender)
        {
            Attacker attacker = GetComponent<Attacker>();
            attacker.Attack(otherObject);
        }
    }

}
