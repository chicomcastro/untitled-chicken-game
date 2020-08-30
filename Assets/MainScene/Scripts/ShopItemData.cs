using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu()]
public class ShopItemData : ScriptableObject
{
    public string Name;
    public Sprite NewSprite;
    public AnimatorController NewAnimation;
    public int Price;
    public string Tag;

    public void ApplyEffect()
    {
        GameObject go = GameObject.FindWithTag(Tag);
        go.GetComponent<SpriteRenderer>().sprite = NewSprite;

        if (NewAnimation != null)
        {
            go.GetComponent<Animator>().runtimeAnimatorController = NewAnimation;
        }
    }
}
