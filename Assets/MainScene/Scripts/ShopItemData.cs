using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ShopItemData : ScriptableObject
{
    public string Name;
    public Sprite NewSprite;
    public int Price;
    public string Tag;

    public bool TryToBuy(Wallet wallet)
    {
        if (wallet.CurrentAmount < Price) return false;

        GameObject go = GameObject.FindWithTag(Tag);
        go.GetComponent<SpriteRenderer>().sprite = NewSprite;

        wallet.ProcessPurchase(Price);
        return true;
    }
}
