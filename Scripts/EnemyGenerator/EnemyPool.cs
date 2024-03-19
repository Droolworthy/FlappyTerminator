using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Enemy _prefab;

    private List<Enemy> _enemies;

    private void Awake()
    {
        _enemies = new List<Enemy>();
    }

    public void ResetSetOfEnemies()
    {
        foreach (var enemy in _enemies)
            enemy.gameObject.SetActive(false);
    }

    public Enemy GetEnemy()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i].gameObject.activeSelf == false)
                return _enemies[i];
        }

        var enemy = CreateEnemy();

        return enemy;
    }

    private Enemy CreateEnemy()
    {
        var enemy = Instantiate(_prefab, _container);

        enemy.Init(_prefab);
        
        enemy.gameObject.SetActive(false);

        _enemies.Add(enemy);

        return enemy;
    }
}