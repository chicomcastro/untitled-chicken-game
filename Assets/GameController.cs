using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private float _elapsed = 0.0f;
    private bool _evolved = false;

    [SerializeField] private ChickController _chickController;
    [SerializeField] private WaterBowlController _waterBowlController;
    [SerializeField] private ExerciseWheelController _exerciseWheelController;
    [SerializeField] private FoodBowlController _foodBowlController;

    void Update()
    {
        if (_evolved)
        {
            return;
        }

        if (_elapsed <= 10)
        {
            _elapsed += Time.deltaTime;
        }
        else
        {
            _chickController.Evolve();
            _evolved = true;
        }
    }

    public void SetChickState(ChickState nextState)
    {
        ToggleCurrentState();
        _chickController.SetState(nextState);
        ToggleCurrentState();
    }

    public void ToggleCurrentState()
    {
        switch (_chickController.ChickState)
        {
            case ChickState.Exercising:
                _exerciseWheelController.ToggleState();
                return;
            case ChickState.DrinkingWater:
                _waterBowlController.ToggleState();
                return;
            case ChickState.Eating:
                _foodBowlController.ToggleState();
                return;
        }
    }
}
