using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Bullet bullet)) 
            bullet.gameObject.SetActive(false);
            gameObject.SetActive(false);

        if (collision.TryGetComponent(out Enemy enemy) && enemy.gameObject.activeSelf == true)
            enemy.gameObject.SetActive(false);

        if (collision.TryGetComponent(out DamageZone damageZone) && gameObject.activeSelf == true)
            gameObject.SetActive(false);
    }
}