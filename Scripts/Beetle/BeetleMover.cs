using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BeetleMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxAngleOfRotationZ;
    [SerializeField] private float _minAngleOfRotationZ;
    [SerializeField] private float _speedRotation;
    [SerializeField] private Vector3 _startPosition;

    private Rigidbody2D _rigidbody;
    private Quaternion _minRotationZ;
    private Quaternion _maxRotationZ;

    private void Awake()
    {
        transform.position = _startPosition;

        _rigidbody = GetComponent<Rigidbody2D>();

        _minRotationZ = Quaternion.Euler(0, 0, _minAngleOfRotationZ);
        _maxRotationZ = Quaternion.Euler(0, 0, _maxAngleOfRotationZ);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            transform.rotation = _maxRotationZ;

            _rigidbody.velocity = new Vector2(_speed, _tapForce);
            _rigidbody.AddForce(new Vector2(_tapForce, _speed * Time.deltaTime));
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotationZ, _speedRotation * Time.deltaTime);
    }

    public void ResetMover()
    {
        transform.SetPositionAndRotation(_startPosition, Quaternion.Euler(0, 0, 0));
        _rigidbody.velocity = Vector2.zero;
    }
}