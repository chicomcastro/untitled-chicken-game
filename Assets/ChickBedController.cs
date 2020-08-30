using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ChickBedController : MonoBehaviour
{
    [SerializeField] private ChickController _chickController;
    [SerializeField] private GameController _gameController;

    private void OnMouseUp()
    {
        _gameController.ResetAllStates();
        _chickController.SetState(ChickState.Idle);
    }
}
