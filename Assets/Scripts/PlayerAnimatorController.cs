using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    //Declarations
    [SerializeField] private string _moveInputParameterName = "MoveInput";
    [SerializeField] private float _horizontalInput = 0;
    [SerializeField] private float _inputDeadzone = .05f;
    private Animator _animatorReference;


    //Monobehaviors
    private void Awake()
    {
        _animatorReference = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateAnimatorUsingHorizontalInput();
    }

    //Utilites
    public void ListenForHorizontalInput(Vector3 input)
    {
        _horizontalInput = input.x;
    }

    private void UpdateAnimatorUsingHorizontalInput()
    {
        if (_horizontalInput > _inputDeadzone)
            _animatorReference.SetInteger(_moveInputParameterName, 1);

        //if input is within deadzone threshold, then set animator int to neutral
        else if (_horizontalInput < _inputDeadzone && _horizontalInput > -_inputDeadzone)
            _animatorReference.SetInteger(_moveInputParameterName, 0);

        else if (_horizontalInput < -_inputDeadzone)
            _animatorReference.SetInteger(_moveInputParameterName, -1);
    }

}
