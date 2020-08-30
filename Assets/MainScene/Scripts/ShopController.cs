using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    [SerializeField] Wallet _wallet;
    [SerializeField] GameObject _shopRoot;
    [SerializeField] Button _shopButton;
    [SerializeField] Button _closeButton;
    [SerializeField] ShopButtonAnimationController _buttonAnimationController;
    [SerializeField] ShopItem _shopItemPrefab;
    [SerializeField] List<ShopItemData> _items;

    private void Awake()
    {
        _shopButton.onClick.AddListener(OpenShop);
        _closeButton.onClick.AddListener(CloseShop);

        foreach (ShopItemData item in _items)
        {
            ShopItem instantiatedShopItem = Instantiate(_shopItemPrefab, _shopRoot.transform);
            instantiatedShopItem.Initialize(_wallet, item);
        }
    }

    void OpenShop()
    {
        StartCoroutine(_buttonAnimationController.StartAnimation(ShopStateAction.Open));
        _shopRoot.gameObject.SetActive(true);
    }

    void CloseShop()
    {
        StartCoroutine(_buttonAnimationController.StartAnimation(ShopStateAction.Close));
        _shopRoot.gameObject.SetActive(false);
    }
}
