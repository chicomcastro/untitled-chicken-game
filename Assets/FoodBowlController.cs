using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class FoodBowlController : MonoBehaviour
{
    private bool _isEatingFood = false;

    [SerializeField] private GameController _gameController;

    private void OnMouseUp()
    {
        _gameController.SetChickState(_isEatingFood ? ChickState.Idle : ChickState.Eating);
    }

    public void ToggleState()
    {
        _isEatingFood = !_isEatingFood;
    }
}
