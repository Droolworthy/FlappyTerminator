using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private BulletGenerator _bulletGenerator;
    [SerializeField] private BulletPool _bulletPool;

    private Enemy _enemy;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var childObject = transform.GetChild(i).gameObject;

            childObject.SetActive(true);
        }

        _bulletPool.ResetSetOfCartridges();
        _bulletGenerator.StartSpawn();
    }


    public void Init(Enemy enemy)
    {
        _enemy = enemy;
    }
}