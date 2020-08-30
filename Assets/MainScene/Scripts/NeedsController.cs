using DefaultNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsController : MonoBehaviour
{
    [SerializeField] GameController _gameController;
    [SerializeField] ChickController _chickController;
    [SerializeField] float initialValue;
    [SerializeField] float decaySpeed;
    [SerializeField] float recoverySpeed;

    Dictionary<ChickState, float> _needs = new Dictionary<ChickState, float>();
    bool _isRunning = true;

    public float GetNeedValue(ChickState need)
    {
        return _needs[need];
    }

    private void Awake()
    {
        foreach (ChickState state in Enum.GetValues(typeof(ChickState)))
        {
            if (state != ChickState.Idle)
            {
                _needs[state] = initialValue;
            }
        }
    }

    private void Update()
    {
        if (!_isRunning) return;

        foreach (ChickState state in Enum.GetValues(typeof(ChickState)))
        {
            if (state == ChickState.Idle || !_isRunning) continue;

            if (state == _chickController.ChickState)
            {
                UpdateNeed(state, recoverySpeed * Time.deltaTime);
            }
            else
            {
                UpdateNeed(state, -decaySpeed * Time.deltaTime);
            }
        }
    }

    private void UpdateNeed(ChickState state, float delta)
    {
        _needs[state] += delta;
        _needs[state] = Mathf.Clamp01(_needs[state]);
        if (_needs[state] == 0)
        {
            _gameController.LoseGame();
            _isRunning = false;
        }    
    }
}
