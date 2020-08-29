using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    Material material;
    private static readonly int ShouldOutline = Shader.PropertyToID("_ShouldOutline");

    private void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void OnMouseOver()
    {
        material.SetFloat(ShouldOutline, 1);
    }

    private void OnMouseExit()
    {
        material.SetFloat(ShouldOutline, 0);
    }
}
