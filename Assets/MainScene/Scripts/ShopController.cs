using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] Wallet _wallet;
    [SerializeField] GameObject _shopRoot;
    [SerializeField] Button _shopButton;
    [SerializeField] ShopItem _shopItemPrefab;
    [SerializeField] List<ShopItemData> _items;

    private void Awake()
    {
        _shopButton.onClick.AddListener(OpenShop);

        foreach (ShopItemData item in _items)
        {
            ShopItem instantiatedShopItem = Instantiate(_shopItemPrefab, _shopRoot.transform);
            instantiatedShopItem.Initialize(_wallet, item);
        }
    }

    void OpenShop()
    {
        _shopButton.gameObject.SetActive(false);
        _shopRoot.gameObject.SetActive(true);
    }

    void CloseShop()
    {
        _shopButton.gameObject.SetActive(true);
        _shopRoot.gameObject.SetActive(false);
    }
}
