using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float spawnTime;
    public Bird[] birds;
    public int timeLimit;

    bool isGameOver;
    int curTimeLimit;
    int birdKilled;

    public bool IsGameOver { get => isGameOver; set => isGameOver = value; }
    public int BirdKilled { get => birdKilled; set => birdKilled = value; }

    public override void Awake()
    {
        MakeSingleton(false);

        curTimeLimit = timeLimit;
    }

    public override void Start()
    {
        StartCoroutine(GameSpawn());    

        StartCoroutine(TimeCountDown());
    }

    IEnumerator TimeCountDown()
    {
        while (curTimeLimit > 0)
        {
            yield return new WaitForSeconds(1f);

            curTimeLimit--;

            if (curTimeLimit <= 0)
            {
                isGameOver = true;
            }
        }
    }
    //Thực hiện cv trong 1 range time chờ nhất định
    IEnumerator GameSpawn()
    {
        while(!isGameOver)
        {
            BirdSpawn();

            yield return new WaitForSeconds(spawnTime);
        }
    }

    void BirdSpawn()
    {
        Vector3 spawnPos = Vector3.zero;

        float randCheck = Random.Range(0f, 1f);

        if (randCheck >= 0.5f )
        {
            spawnPos = new Vector3(12, Random.Range(-4f, 4f), 0);
        }
        else
        {
            spawnPos = new Vector3(-12, Random.Range(-4f, 4f), 0);
        }

        if (birds != null && birds.Length > 0)
        {
            int randIdx = Random.Range(0, birds.Length);

            if (birds[randIdx] != null)
            {
                Bird birdClone = Instantiate(birds[randIdx], spawnPos, Quaternion.identity);
            }
        }
    }
}
