using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private int _poolCapacity = 15;
    [SerializeField] private int _poolMaxSize = 20;

    private Coroutine _coroutine;
    private ObjectPool<Enemy> _pool;

    private void Start()
    {
        CreatePool();
        StartCoroutine(SpawnEnemies());
    }

    private void CreatePool()
    {
        _pool = new ObjectPool<Enemy>(
            createFunc: () => Instantiate(_enemyPrefab),
            actionOnGet: (enemy) => ActionOnGet(enemy),
            actionOnRelease: (enemy) => enemy.gameObject.SetActive(false),
            actionOnDestroy: (enemy) => Destroy(enemy.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
            );
    }

    private void ActionOnGet(Enemy enemy)
    {
        enemy.transform.position = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;

        enemy.InitializeAction(ReturnInPool);
        enemy.SetDirection(GetDirection());

        enemy.gameObject.SetActive(true);
    }

    private Vector3 GetDirection()
    {
        float minValue = -1;
        float maxValue = 1;

        Vector3 direction = new(Random.Range(minValue, maxValue), 0, Random.Range(minValue, maxValue));

        return direction;
    }

    private void ReturnInPool(Enemy enemy)
    {
        _pool.Release(enemy);
    }

    private void Spawn()
    {
        _pool.Get();
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
