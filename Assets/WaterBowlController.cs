﻿using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class WaterBowlController : MonoBehaviour
{
    private bool _isDrinkingWater = false;

    [SerializeField] private GameController _gameController;

    private void OnMouseUp()
    {
        _gameController.SetChickState(_isDrinkingWater ? ChickState.Idle : ChickState.DrinkingWater);
    }

    public void ToggleState()
    {
        _isDrinkingWater = !_isDrinkingWater;
    }
}
