using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    //Declarations
    [SerializeField] private float _toggleDuration = 7;
    [SerializeField] private float _speedBoost = 5;
    private float _currentDuration = 0;
    private bool _isSpeedBoostActive = false;

    private MoveObject _moveObjectReference;

    //Monobehaviors
    private void Awake()
    {
        _moveObjectReference = GetComponent<MoveObject>();
    }

    private void Update()
    {
        CountDuration();
    }



    //Utilities
    private void CountDuration()
    {
        if (_isSpeedBoostActive)
        {
            _currentDuration += Time.deltaTime;

            if (_currentDuration >= _toggleDuration)
            {
                _moveObjectReference.SetSpeed(_moveObjectReference.GetSpeed() - _speedBoost);
                _isSpeedBoostActive = false;
                _currentDuration = 0;
            }
        }
    }

    public void EnableSpeedBoost()
    {
        _moveObjectReference.SetSpeed(_speedBoost + _moveObjectReference.GetSpeed());
        _isSpeedBoostActive = true;
        _currentDuration = 0;
    }
}
