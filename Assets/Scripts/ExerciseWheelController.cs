using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExerciseWheelController : MonoBehaviour
{
    private Animator _animator;
    private bool _isExercising = false;
    private static readonly int IsExercising = Animator.StringToHash("isExercising");

    [SerializeField] private GameController _gameController;

    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    private void OnMouseUp()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        _gameController.SetChickState(_isExercising ? ChickState.Idle : ChickState.Exercising);
    }

    public void ToggleState()
    {
        if (_animator == null)
        {
            return;
        }

        _isExercising = !_isExercising;
        _animator.SetBool(IsExercising, _isExercising);
    }

    void Update()
    {
        
    }
}
