using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWindowController : MonoBehaviour
{
    [SerializeField] private TMP_Text _finalText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private GameObject _deadRooster;
    [SerializeField] private GameObject _rooster;
    [SerializeField] private GameObject _nuggets;

    private void Start()
    {
        _restartButton.onClick.AddListener(() =>
        {
            ScenesManager.Instance.ChangeScene(ScenesManager.Scenes.InitialMenu);
        });
    }

    public void Setup(int nuggets, bool lost)
    {
        SoundManager.Instance.SetSong(SoundManager.Instance.Funkao);
        if (lost)
        {
            _finalText.text = "Que triste! Seu frango ficou muito fraquinho e morreu!!";
            _deadRooster.SetActive(true);
            _rooster.SetActive(false);
            _nuggets.SetActive(false);
            return;
        }
        if (nuggets > 0)
        {
            _finalText.text =
                $"Que triste! Seu vizinho roubou seu frango e com ele fez {nuggets} nuggets!! \n" +
                "Pelo menos ele era saudável....";
            _deadRooster.SetActive(false);
            _rooster.SetActive(false);
            _nuggets.SetActive(true);
            return;
        }
        else
        {
            _finalText.text =
                $"Seu frango viveu feliz e saudável!! \n" +
                "Você venceu";
            _deadRooster.SetActive(false);
            _rooster.SetActive(true);
            _nuggets.SetActive(false);
            return;
        }
    }
}
