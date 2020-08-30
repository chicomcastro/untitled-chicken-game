using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private Button _forwardButton;
    private void Start()
    {
        _forwardButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.SetSong(SoundManager.Instance.LofiN3);
            ScenesManager.Instance.ChangeScene(ScenesManager.Scenes.MainScene);
        });
    }
}
