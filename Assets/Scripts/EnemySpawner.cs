using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public float spawnInterval = 1.0f;
    public int poolSize = 20; 

    private Camera mainCamera;
    private float halfHeight;
    private float halfWidth;

    private List<GameObject> enemyPool;

    void Start()
    {
        mainCamera = Camera.main;
        halfHeight = mainCamera.orthographicSize;
        halfWidth = halfHeight * mainCamera.aspect;

        enemyPool = new List<GameObject>();

        // Pre-instantiate enemies and add to the pool.
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }

        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Decide whether to spawn the enemy on the left (-1) or right (+1) side.
            int leftOrRight = Random.Range(0, 2) * 2 - 1;

            // Spawn enemy on the left or right side just outside of the viewport.
            Vector3 spawnPosition = new Vector3(mainCamera.transform.position.x + leftOrRight * (halfWidth + 1), 0, 0);

            // Fetch an inactive enemy from the pool.
            GameObject enemy = GetPooledEnemy();

            if (enemy != null)  // Ensure we have an available enemy in the pool.
            {
                enemy.transform.position = spawnPosition;
                enemy.SetActive(true);
            }
        }
    }

    private GameObject GetPooledEnemy()
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy)
            {
                return enemy;
            }
        }
        return null;  // All enemies in the pool are active.
    }
}
