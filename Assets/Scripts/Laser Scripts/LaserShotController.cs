using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShotController : MonoBehaviour
{
    //Declarations
    [SerializeField] private Vector3 _shotDirection = Vector3.back;
    [SerializeField] private float _cooldownDuration = .3f;
    [SerializeField] private bool _isShotReady = true;
    [SerializeField] private bool _shootCommand = false;
    [SerializeField] private bool _isShootingEnabled = true;
    [SerializeField] private bool _isTripleShotEnabled = false;
    private SpawnLaser _spawnLaserScriptReference;

    //Monobehaviors
    private void Awake()
    {
        _spawnLaserScriptReference = GetComponent<SpawnLaser>();
    }

    private void Update()
    {
        ShootOnCommand();
    }

    //Utilities
    private void ShootOnCommand()
    {
        if (_isShotReady && _isShootingEnabled && _shootCommand)
        {
            if (_isTripleShotEnabled)
                _spawnLaserScriptReference.CreateTripleLaser(_shotDirection);
            else
                _spawnLaserScriptReference.CreateLaser(_shotDirection);

            _isShotReady = false;
            CooldownShot();
        }
    }

    private void CooldownShot()
    {
        Invoke("ReadyShot", _cooldownDuration);
    }

    private void ReadyShot()
    {
        _isShotReady = true;
    }

    public void SetShootCommand(bool command)
    {
        _shootCommand = command;
    }

    public void SetShotEnabled(bool newValue)
    {
        _isShootingEnabled = newValue;
    }

    public bool IsShootingEnabled()
    {
        return _isShootingEnabled;
    }

    public bool IsTripleShotEnabled()
    {
        return _isTripleShotEnabled;
    }

    public void SetTripleShotEnabled(bool newValue)
    {
        _isTripleShotEnabled = newValue;
    }
}
