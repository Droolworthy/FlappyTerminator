using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;
    [SerializeField] private int _delay;

    private Coroutine _coroutine;

    private void Awake()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(GenerateEnemies(_delay));
    }

    private IEnumerator GenerateEnemies(int delay)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            Spawn();

            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);

        var spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
        var enemy = _enemyPool.GetEnemy();

        enemy.gameObject.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}