﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] int _initialAmount;
    int _amount;

    public int CurrentAmount => _amount;
    public Action<int> OnAmountChange;

    private void Awake()
    {
        _amount = _initialAmount;
        StartCoroutine(StartDefaultIncome());
    }

    public bool TryToBuy(ShopItemData item)
    {
        if (_amount < item.Price) return false;

        item.ApplyEffect();
        ProcessPurchase(item.Price);
        return true;
    }

    private void ProcessPurchase(int value)
    {
        _amount -= value;
        OnAmountChange?.Invoke(_amount);
    }

    private IEnumerator StartDefaultIncome()
    {
        while (true)
        {
            _amount++;
            OnAmountChange?.Invoke(_amount);
            yield return new WaitForSeconds(1);
        }
    }
}
