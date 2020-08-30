using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WalletDisplay : MonoBehaviour
{
    [SerializeField] Wallet _wallet;
    [SerializeField] TMP_Text _display;

    private void Start()
    {
        _wallet.OnAmountChange += UpdateDisplay;
        _display.text = $"<sprite name=\"pena\">{_wallet.CurrentAmount}";
    }

    public void UpdateDisplay(int newValue)
    {
        _display.text = $"<sprite name=\"pena\">{newValue}";
    }
}
