using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private float _elapsed = 0.0f;
    private bool _evolved = false;
    private bool _finished = false;
    private float _score = 0;

    [SerializeField] private ChickController _chickController;
    [SerializeField] private WaterBowlController _waterBowlController;
    [SerializeField] private ExerciseWheelController _exerciseWheelController;
    [SerializeField] private FoodBowlController _foodBowlController;
    [SerializeField] private GameObject _watcher;
    [SerializeField] private NeedsController _needsController;

    private void Start()
    {
        StartCoroutine(InterpolateWatcherIfNeeded());
        _score = 0;
    }

    void Update()
    {
        _elapsed += Time.deltaTime;
        EvolveIfNeeded();
        FinishGameIfNeeded();
    }

    private IEnumerator InterpolateWatcherIfNeeded()
    {
        var watcherStep = new Vector3(-0.02f, +0.02f);
        while (gameObject != null)
        {
            yield return new WaitForSeconds(20);

            for (int i = 0; i < 100; i++)
            {
                _watcher.transform.position += watcherStep;
                yield return null;
            }
            
            yield return new WaitForSeconds(2);
            
            for (int i = 0; i < 100; i++)
            {
                _watcher.transform.position -= watcherStep;
                yield return null;
            }
        }
    }

    private void EvolveIfNeeded()
    {
        if (_evolved)
        {
            return;
        }

        if (_elapsed > 90)
        {
            _chickController.Evolve();
            _evolved = true;
        }
    }

    private void FinishGameIfNeeded()
    {
        if (_finished) return;

        if (_elapsed > 150)
            WinGame();
    }

    public void SetChickState(ChickState nextState)
    {
        ToggleCurrentState();
        _chickController.SetState(nextState);
        switch (nextState)
        {
            case ChickState.Idle:
                SoundManager.Instance.StopSound();
                break;
            case ChickState.Exercising:
                SoundManager.Instance.PlaySound(SoundManager.Instance.Clucking, loop: true);
                break;
            case ChickState.DrinkingWater:
                SoundManager.Instance.PlaySound(SoundManager.Instance.Eating, loop: true);
                break;
            case ChickState.Eating:
                SoundManager.Instance.PlaySound(SoundManager.Instance.Eating, loop: true);
                break;
        }
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

    public void IncreaseScore(float bonus)
    {
        _score += bonus;
    }

    private void WinGame()
    {
        _finished = true;
        foreach (ChickState state in Enum.GetValues(typeof(ChickState)))
            if (state != ChickState.Idle)
                _score += 30 * _needsController.GetNeedValue(state);

        Debug.Log($"Win score: {_score}");
    }

    public void LoseGame()
    {
        _finished = true;
        Debug.Log("Lost");
    }
}
