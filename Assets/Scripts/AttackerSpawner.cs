using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpawnTime = 1;
    [SerializeField] float maxSpawnTime = 5;
    [SerializeField] Attacker lizard;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            Spawn();
        }
    }


    private void Spawn()
    {
        Instantiate(lizard, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
