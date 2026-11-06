using System.Collections;
using UnityEngine;

public class PigSpawner : MonoBehaviour
{
    [SerializeField] private GameObject balloonPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval = 10f;
    [SerializeField] private int balloonsPerWave = 3;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            for (int i = 0; i < balloonsPerWave; i++)
            {
                Transform point =
                    spawnPoints[Random.Range(0, spawnPoints.Length)];

                Instantiate(
                    balloonPrefab,
                    point.position,
                    Quaternion.identity
                );

                yield return new WaitForSeconds(0.5f);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
} 