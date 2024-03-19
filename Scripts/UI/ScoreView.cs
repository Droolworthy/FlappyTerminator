using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private BeetleScore _amount;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _amount.AccountChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _amount.AccountChanged -= ChangeValue;
    }

    private void ChangeValue(int amount)
    {
        _text.text = amount.ToString();
    }
}