using System;
using UnityEngine;

public class EndScreen : Display
{
    public event Action RestartButtonClick;

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        ActionButton.interactable = true;
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        ActionButton.interactable = false;
    }

    protected override void OnButtonClick()
    {
        RestartButtonClick?.Invoke();
    }
}