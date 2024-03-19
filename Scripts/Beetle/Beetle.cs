using System;
using UnityEngine;

[RequireComponent (typeof(BeetleMover))]
[RequireComponent(typeof(BeetleScore))]
public class Beetle : MonoBehaviour
{
    [SerializeField] private BulletGenerator _bulletGenerator;

    private BeetleMover _mover;
    private BeetleScore _score;

    public event Action Died;

    private void Awake()
    {
        _mover = GetComponent<BeetleMover>();
        _score = GetComponent<BeetleScore>();    
    }

    private void Update()
    {
        int leftMouse = 0;

        if (Input.GetMouseButtonDown(leftMouse))
        {
            _bulletGenerator.Shoot();
        }
    }

    public void ResetPlayer()
    {
        _score.ResetBill();
        _mover.ResetMover();
    }

    public void Die()
    {
        Died?.Invoke();
    }
}