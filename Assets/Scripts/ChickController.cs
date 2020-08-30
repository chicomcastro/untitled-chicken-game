using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChickController : MonoBehaviour
{
    private Animator _animator = null;
    private static readonly int AnimatorState = Animator.StringToHash("State");
    
    private ChickState _chickState = ChickState.Idle;

    [SerializeField] private GameObject _idlePosition;
    [SerializeField] private GameObject _waterPosition;
    [SerializeField] private GameObject _wheelPosition;
    [SerializeField] private GameObject _foodPosition;
    [SerializeField] private GameController _gameController;
    [SerializeField] private RuntimeAnimatorController _roosterAnimatorController;
    [SerializeField] private GameObject _evolveEffect;

    private void Start()
    {
        var parentObject = gameObject;
        _animator = parentObject.GetComponent<Animator>();
        parentObject.transform.position = _idlePosition.transform.position;
    }

    public ChickState ChickState => _chickState;

    public void SetState(ChickState nextState)
    {
        Vector3 newPosition = Vector3.zero;
        switch (nextState)
        {
            case ChickState.Exercising:
                newPosition = _wheelPosition.transform.position;
                break;
            case ChickState.DrinkingWater:
                newPosition = _waterPosition.transform.position;
                break;
            case ChickState.Eating:
                newPosition = _foodPosition.transform.position;
                break;
            case ChickState.Idle:
                newPosition = _idlePosition.transform.position;
                break;
        }

        _animator.SetInteger(AnimatorState, (int) nextState);
        gameObject.transform.position = newPosition;
        _chickState = nextState;
    }

    public void Evolve()
    {
        _animator.runtimeAnimatorController = _roosterAnimatorController;
        _wheelPosition.transform.position += new Vector3(0.15f, 0.23f);
        SetState(_chickState);
        Instantiate(_evolveEffect, this.gameObject.transform.position, Quaternion.identity, this.transform);
    }
}
