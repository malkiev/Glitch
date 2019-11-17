using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] bool timerExpired;
    [SerializeField] int attackersCount;
    [SerializeField] float timeToShowLevelComplete = 5;
    [SerializeField] GameObject winLabel;
    [SerializeField] AudioSource finishedLevelAudio;

    // Start is called before the first frame update
    void Start()
    {
        timerExpired = false;
        winLabel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);

        finishedLevelAudio.Play();

        yield return new WaitForSeconds(timeToShowLevelComplete);

        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void AddAttacker()
    {
        attackersCount++;
    }

    public void RemoveAttacker()
    {
        attackersCount--;

        if (timerExpired && attackersCount == 0)
        {
            Debug.Log("End LEvel Now");
            StartCoroutine(HandleWinCondition());
        }
    }

    public void TimerExpired()
    {
        timerExpired = true;
        StopSpawners();
    }

    private static void StopSpawners()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (var spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }
}
