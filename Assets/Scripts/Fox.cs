using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D othercollider)
    {
        GameObject otherObject = othercollider.gameObject;
        

        Defender defender = otherObject.GetComponent<Defender>();
        if (defender)
        {
            Attacker attacker = GetComponent<Attacker>();
            attacker.Attack(otherObject);
        }

        Gravestone gravestone = otherObject.GetComponent<Gravestone>();
        if (gravestone)
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
            GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }
}
