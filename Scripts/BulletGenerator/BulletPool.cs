using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private int _capacity;

    private List<Bullet> _bullets;

    private void Awake()
    {
        _bullets = new List<Bullet>();
    }

    public void ResetSetOfCartridges()
    {
        foreach (var bullet in _bullets)
            bullet.gameObject.SetActive(false);
    }

    public Bullet GetCartridge()
    {
        for (int i = 0; i < _bullets.Count; i++)
        {
            if (_bullets[i].gameObject.activeSelf == false)
                return _bullets[i];
        }

        return null;
    }

    public void CreateCartridge()
    {
        for (int i = 0; i < _capacity; i++)
        {
            Bullet bullet = Instantiate(_prefab, _container);
            
            bullet.InitCartridge(_prefab);
            bullet.SetDirection(Vector3.left);
            bullet.gameObject.SetActive(false);

            _bullets.Add(bullet);
        }
    }
}