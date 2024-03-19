using System.Collections;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private BulletPool _pool;
    [SerializeField] private Beetle _beetle;
    [SerializeField] private int _delay;

    private Coroutine _coroutine;
    private Bullet _bullets;

    private void Start()
    {
        _pool.CreateCartridge();
    }

    public void StartSpawn()
    {
        _pool.CreateCartridge();

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(GenerateCartridges(_delay));
    }

    public void Shoot()
    {
        Spawn();

        _bullets.SetDirection(transform.right);
        _bullets.transform.rotation = _beetle.transform.rotation;
    }

    private void Spawn()
    {
        _bullets = _pool.GetCartridge();
        _bullets.gameObject.SetActive(true);
        _bullets.transform.position = _spawnPoint.transform.position;
    }

    private IEnumerator GenerateCartridges(int delay) 
    {
        var wait = new WaitForSeconds(delay);

        bool isWork = true;

        while (isWork)
        {
            Spawn();

            yield return wait;
        }
    }
}