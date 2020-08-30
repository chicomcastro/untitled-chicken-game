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

    public void ApplyEffect()
    {
        GameObject go = GameObject.FindWithTag(Tag);
        go.GetComponent<SpriteRenderer>().sprite = NewSprite;
    }
}
