using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReadInput : MonoBehaviour
{
    //Declarations
    [SerializeField] private Vector3 _inputDirection;
    [SerializeField] private bool _shootInput;

    [Space(20)] public UnityEvent<Vector3> UpdateMoveInput;
    [Space(20)] public UnityEvent<bool> UpdateShotInput;


    //Monobehaviors
    private void Update()
    {
        ReadAndCommunicateMoveInput();
        ReadAndCommunicateShotInput();
    }


    //Utilities
    private void ReadAndCommunicateMoveInput()
    {
        _inputDirection.x = Input.GetAxis("Horizontal");
        _inputDirection.y = Input.GetAxis("Vertical");

        UpdateMoveInput.Invoke(_inputDirection);
    }

    private void ReadAndCommunicateShotInput()
    {
        _shootInput = Input.GetKey(KeyCode.Space);

        UpdateShotInput.Invoke(_shootInput);
    }


}
