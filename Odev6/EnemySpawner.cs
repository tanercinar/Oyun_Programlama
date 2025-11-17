using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public GameObject[] array;
    
    private float minX = -4.8f;
    private float maxX = 4.8f;
    private float spawnYPosition = 20f;
    private float waitTime = 1f;
    public float waitTime2 = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnBonusRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            float randomX = UnityEngine.Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, spawnYPosition, 0f);

            Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(waitTime);
        }
    }
    
    IEnumerator SpawnBonusRoutine()
    {
        while (true)
        {
            float randomX = UnityEngine.Random.Range(minX, maxX);

            yield return new WaitForSeconds(waitTime2);

            Vector3 spawnPosition = new Vector3(randomX, spawnYPosition, 0f);
            int a=UnityEngine.Random.Range(0, 3);
            Instantiate(array[a], spawnPosition, Quaternion.identity);
        }
    }
}