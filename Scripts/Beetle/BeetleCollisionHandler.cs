using UnityEngine;

[RequireComponent (typeof(Beetle))]
public class BeetleCollisionHandler : MonoBehaviour 
{
    [SerializeField] private Beetle _player;
    [SerializeField] private BeetleScore _score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ScoreZone scoreZone))
            _score.AddBill();

        if (collision.TryGetComponent(out DamageZone zone))
            _player.Die();

        if (collision.TryGetComponent(out Bullet bullet))
            _player.Die();
    }
}