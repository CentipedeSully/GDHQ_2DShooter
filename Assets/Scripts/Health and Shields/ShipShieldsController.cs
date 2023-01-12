using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipShieldsController : MonoBehaviour
{
    //Declarations
    [Header("Shields Settings")]
    [SerializeField] private int _shieldLevel = 0;
    [SerializeField] private int _shieldMax = 3;

    [Header("Shields Events")]
    public UnityEvent OnShieldsGained;
    public UnityEvent OnShieldsStrengthened;
    public UnityEvent OnShieldsDamaged;
    public UnityEvent OnShieldsLost;

    //references
    private LivesController _shieldsUIController;


    //Monbehaviors
    private void Awake()
    {
        _shieldsUIController = GameObject.Find("Shields Display").GetComponent<LivesController>();
    }


    //Utilties
    public bool IsShieldsActive()
    {
        return _shieldLevel > 0;
    }

    public void DamageShields()
    {
        if (_shieldLevel > 1)
        {
            _shieldLevel--;
            OnShieldsDamaged?.Invoke();
        }
        else if (_shieldLevel == 1)
        {
            _shieldLevel--;
            OnShieldsLost?.Invoke();
        }

        _shieldsUIController.SetImage(_shieldLevel);
    }

    public void GainShields()
    {
        if (_shieldLevel == 0)
        {
            _shieldLevel++;
            OnShieldsGained?.Invoke();
        }
        else if (_shieldLevel < _shieldMax)
        {
            _shieldLevel++;
            OnShieldsStrengthened?.Invoke();
        }

        _shieldsUIController.SetImage(_shieldLevel);

    }
}
