using System;
using UnityEngine;
using UnityEngine.UI;

public class InitialMenuController : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _aboutButton;

    private void Start()
    {
        _playButton.onClick.AddListener(() =>
        {
            ScenesManager.Instance.ChangeScene(ScenesManager.Scenes.FirstCutscene);
        });
    }
}
