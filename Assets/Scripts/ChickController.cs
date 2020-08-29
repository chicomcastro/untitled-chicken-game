using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ChickController : MonoBehaviour
{
    private Animator _animator = null;
    private static readonly int AnimatorState = Animator.StringToHash("State");
    
    private ChickState _chickState = ChickState.Idle;

    [SerializeField] private GameObject _idlePosition;
    [SerializeField] private GameObject _waterPosition;
    [SerializeField] private GameObject _wheelPosition;

    private void Start()
    {
        var parentObject = gameObject;
        _animator = parentObject.GetComponent<Animator>();
        parentObject.transform.position = _idlePosition.transform.position;
    }

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
}
