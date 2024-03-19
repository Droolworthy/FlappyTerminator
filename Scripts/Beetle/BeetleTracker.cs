using UnityEngine;

public class BeetleTracker : MonoBehaviour
{
    [SerializeField] private Beetle _beetle;
    [SerializeField] private int _distanceOffsetCamera;

    private void Update()
    {
        var position = transform.position;

        position.x = _beetle.transform.position.x + _distanceOffsetCamera;

        transform.position = position;
    }
}