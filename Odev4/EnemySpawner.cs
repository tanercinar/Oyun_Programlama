using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    
    private float minX = -4.8f;
    private float maxX = 4.8f;
    private float spawnYPosition = 10f; 
    private float waitTime = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float randomX = Random.Range(minX, maxX);
            Vector3 spawnPosition = new Vector3(randomX, spawnYPosition, -20f);
            
            Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
            
            yield return new WaitForSeconds(waitTime);
        }
    }
}