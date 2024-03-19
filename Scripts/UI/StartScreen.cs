using System;
using UnityEngine;

public class StartScreen : Display
{
    public event Action PerformButtonClick; 

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
        PerformButtonClick?.Invoke();
    }
}