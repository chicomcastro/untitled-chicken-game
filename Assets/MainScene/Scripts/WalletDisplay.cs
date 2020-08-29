using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalletDisplay : MonoBehaviour
{
    [SerializeField] Wallet _wallet;
    [SerializeField] Text _display;

    private void Start()
    {
        _wallet.OnAmountChange += UpdateDisplay;
        _display.text = _wallet.CurrentAmount.ToString();
    }

    public void UpdateDisplay(int newValue)
    {
        _display.text = newValue.ToString();
    }
}
