using System;
using UnityEngine;
using UnityEngine.UI;

public class ClickListener : MonoBehaviour
{
    private void Start()
    {
        if (gameObject.TryGetComponent<Button>(out var button))
        {
            button.onClick.AddListener(OnMouseUp);
        }
    }

    private void OnMouseUp()
    {
        SoundManager.Instance.PlayClick();
    }
}
