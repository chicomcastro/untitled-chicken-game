using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedsDisplay : MonoBehaviour
{
    [SerializeField] NeedsController _needsController;
    [SerializeField] Slider _exerciseDisplay;
    [SerializeField] Slider _waterDisplay;
    [SerializeField] Slider _foodDisplay;

    private void Update()
    {
        _exerciseDisplay.value = _needsController.GetNeedValue(ChickState.Exercising);
        _waterDisplay.value = _needsController.GetNeedValue(ChickState.DrinkingWater);
        _foodDisplay.value = _needsController.GetNeedValue(ChickState.Eating);
    }
}
