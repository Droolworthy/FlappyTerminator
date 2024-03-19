using System;
using UnityEngine;

public class BeetleScore : MonoBehaviour
{
    private int _score;

    public event Action <int> AccountChanged;

    public void AddBill()
    {
        _score++;

        AccountChanged?.Invoke(_score);
    }

    public void ResetBill()
    {
        _score = 0;

        AccountChanged?.Invoke(_score);
    }
}