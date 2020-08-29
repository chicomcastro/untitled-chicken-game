using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Text _nameSlot;
    [SerializeField] Text _priceSlot;
    Wallet _wallet;
    ShopItemData _item;

    public void Initialize(Wallet wallet, ShopItemData item)
    {
        _wallet = wallet;
        _item = item;

        _nameSlot.text = item.Name;
        _priceSlot.text = item.Price.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_item.TryToBuy(_wallet))
            gameObject.SetActive(false);
    }
}
