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

    public void ResetAllStates()
    {
        if (_chickController.ChickState == ChickState.Exercising)
        {
            _exerciseWheelController.ToggleState();
        }
        
        if (_chickController.ChickState == ChickState.DrinkingWater)
        {
            _waterBowlController.ToggleState();
        }
        
    }
}
