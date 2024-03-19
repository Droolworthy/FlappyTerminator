using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Bullet _bullet;
    private Vector3 _direction;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _direction, Space.World);
    }

    public void InitCartridge(Bullet bullet)
    {
        _bullet = bullet;
    }

    public void SetDirection(Vector3 direction) 
    {
        _direction = direction;
    }
}