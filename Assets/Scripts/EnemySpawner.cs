using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Your enemy prefab.
    public float spawnInterval = 1.0f; // Interval between spawns.

    private Camera mainCamera; // Main camera.
    private float halfHeight;
    private float halfWidth;

    void Start()
    {
        mainCamera = Camera.main;
        halfHeight = mainCamera.orthographicSize;
        halfWidth = halfHeight * mainCamera.aspect;

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
            

            // Instantiate the enemy prefab at the spawn position.
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
