using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    Material material;

    private void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void OnMouseOver()
    {
        material.SetFloat("_ShouldOutline", 1);
    }

    private void OnMouseExit()
    {
        material.SetFloat("_ShouldOutline", 0);
    }
}
