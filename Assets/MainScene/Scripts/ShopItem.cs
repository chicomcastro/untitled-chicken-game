﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] TMP_Text _nameSlot;
    [SerializeField] Image _iconSlot;
    [SerializeField] TMP_Text _priceSlot;
    Wallet _wallet;
    ShopItemData _item;

    public void Initialize(Wallet wallet, ShopItemData item)
    {
        _wallet = wallet;
        _item = item;

        _nameSlot.text = item.Name;
        _iconSlot.sprite = item.NewSprite;
        _priceSlot.text = item.Price.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_wallet.TryToBuy(_item))
            gameObject.SetActive(false);
    }
}
