using System;
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
            var currentAnimator = go.GetComponent<Animator>();
            var currentAnimatorProperties = currentAnimator.parameters;
            currentAnimator.runtimeAnimatorController = NewAnimation;
            for (int i = 0; i < currentAnimatorProperties.Length; i++)
            {
                var hash = currentAnimatorProperties[i].nameHash;
                switch (currentAnimatorProperties[i].type)
                {
                    case AnimatorControllerParameterType.Float:
                        currentAnimator.SetFloat(hash, currentAnimatorProperties[i].defaultFloat);
                        break;
                    case AnimatorControllerParameterType.Int:
                        currentAnimator.SetInteger(hash, currentAnimatorProperties[i].defaultInt);
                        break;
                    case AnimatorControllerParameterType.Bool:
                        currentAnimator.SetBool(hash, currentAnimatorProperties[i].defaultBool);
                        break;
                    case AnimatorControllerParameterType.Trigger:
                        currentAnimator.SetTrigger(hash);
                        break;
                }
            }
        }
    }
}
