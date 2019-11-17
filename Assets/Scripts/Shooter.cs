using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach (var attackerSpawner in attackerSpawners)
        {
            bool isCloseEnough = Mathf.Abs(attackerSpawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;

            if (isCloseEnough)
            {
                myLaneSpawner = attackerSpawner;
            }
        }
    }


    private void Update()
    {
        if (IsAttackerInLane())
        {
            //TODO Change animation state to shooting
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            //TODO Change animation state to idle
            animator.SetBool("IsAttacking", false);
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        return true;
    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }

}
