using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class WaterBowlController : MonoBehaviour
{
    private bool _isDrinkingWater = false;

    [SerializeField] private ChickController _chickController;

    private void OnMouseUp()
    {
        ToggleState();
    }

    public void ToggleState()
    {
        var stateSet = _chickController.SetState(_isDrinkingWater ? ChickState.Idle : ChickState.DrinkingWater);
        if (!stateSet) return;

        _isDrinkingWater = !_isDrinkingWater;
    }
}
