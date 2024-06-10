using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private void Spawn()
    {
        Enemy enemy = Instantiate(_enemyPrefab, _spawnPoints[Random.Range(0, _spawnPoints.Length)]);

        enemy.SetDirection(GetDirection());
    }

    private Vector3 GetDirection()
    {
        float minValue = -1;
        float maxValue = 1;

        return new Vector3(Random.Range(minValue, maxValue), 0, Random.Range(minValue, maxValue));
    }

    private IEnumerator SpawnEnemies()
    {
        float delay = 2f;

        var wait = new WaitForSecondsRealtime(delay);

        while (true)
        {
            Spawn();
            yield return wait;
        }
    }
}