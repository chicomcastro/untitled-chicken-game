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
    [SerializeField] private RuntimeAnimatorController _roosterAnimatorController;

    private void Start()
    {
        var parentObject = gameObject;
        _animator = parentObject.GetComponent<Animator>();
        parentObject.transform.position = _idlePosition.transform.position;
    }

    public ChickState ChickState => _chickState;

    public bool SetState(ChickState nextState) => TransitionState(_chickState, nextState);
    private bool TransitionState(ChickState previousState, ChickState nextState)
    {
        Vector3 newPosition = Vector3.zero;
        if (previousState == ChickState.Idle && nextState == ChickState.Exercising)
        {
            newPosition = _wheelPosition.transform.position;
        }
        else if (previousState == ChickState.Idle && nextState == ChickState.DrinkingWater)
        {
            newPosition = _waterPosition.transform.position;
        } else if (previousState != ChickState.Idle && nextState == ChickState.Idle)
        {
            newPosition = _idlePosition.transform.position;
        }

        if (newPosition.Equals(Vector3.zero))
        {
            return false; // Illegal state
        }

        _animator.SetInteger(AnimatorState, (int) nextState);
        gameObject.transform.position = newPosition;
        _chickState = nextState;
        return true;
    }

    public void Evolve()
    {
        _animator.runtimeAnimatorController = _roosterAnimatorController;
        _wheelPosition.transform.position += new Vector3(0.15f, 0.23f);
        switch (_chickState)
        {
            case ChickState.Idle:
                gameObject.transform.position = _idlePosition.transform.position;
                break;
            case ChickState.Exercising:
                gameObject.transform.position = _wheelPosition.transform.position;
                break;
            case ChickState.DrinkingWater:
                gameObject.transform.position = _waterPosition.transform.position;
                break;
        }
        _animator.SetInteger(AnimatorState, (int) _chickState);
    }
}
