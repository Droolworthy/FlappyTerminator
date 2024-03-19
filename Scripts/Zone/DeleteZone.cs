using UnityEngine;

public class DeleteZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy) && enemy.gameObject.activeSelf == true)
            enemy.gameObject.SetActive(false);

        if (collision.TryGetComponent(out Bullet bullet) && bullet.gameObject.activeSelf == true)
            bullet.gameObject.SetActive(false);
    }
}
