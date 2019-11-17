using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] bool spawn = true;
    [SerializeField] float minSpawnTime = 1;
    [SerializeField] float maxSpawnTime = 5;
    [SerializeField] Attacker[] attackerPrefabArray;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            Spawn();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void Spawn()
    {
        if (!spawn)
        {
            return;
        }

        int index = Random.Range(0, attackerPrefabArray.Length);
        Attacker newAttacker = Instantiate(attackerPrefabArray[index], transform.position, transform.rotation, transform) as Attacker;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
