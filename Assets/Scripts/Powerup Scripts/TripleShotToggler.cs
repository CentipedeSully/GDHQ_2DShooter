using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShotToggler : MonoBehaviour
{
    //Declarations
    [SerializeField] private float _toggleDuration = 7;
    private float _currentDuration = 0;
    private bool _isTripleShotActive = false;

    private LaserShotController _shotControllerReference;

    //Monobehaviors
    private void Awake()
    {
        _shotControllerReference = GetComponent<LaserShotController>();
    }

    private void Update()
    {
        CountDuration();
    }



    //Utilities
    private void CountDuration()
    {
        if (_isTripleShotActive)
        {
            _currentDuration += Time.deltaTime;

            if (_currentDuration >= _toggleDuration)
            {
                _shotControllerReference.SetTripleShotEnabled(false);
                _isTripleShotActive = false;
                _currentDuration = 0;
            }
        }
    }

    public void EnableTripleShot()
    {
        _shotControllerReference.SetTripleShotEnabled(true);
        _isTripleShotActive = true;
        _currentDuration = 0;
    }
}
