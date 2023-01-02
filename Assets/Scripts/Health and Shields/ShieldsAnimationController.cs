using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldsAnimationController : MonoBehaviour
{
    //Declarations
    [SerializeField] private string _shieldAnimBoolName;
    [SerializeField] private string _shieldAnimTriggerName;
    private Animator _shieldAnimator;


    //Monobehaviors
    private void Awake()
    {
        _shieldAnimator = GetComponent<Animator>();
    }


    //Utilities
    public void PlayShieldDamagedAnim()
    {
        _shieldAnimator.SetTrigger(_shieldAnimTriggerName);
        //_shieldAnimator.ResetTrigger(_shieldAnimTriggerName);
    }

    public void PlayEnableShieldsAnim()
    {
        _shieldAnimator.SetBool(_shieldAnimBoolName, true);
    }

    public void PlayDisableShieldsAnim()
    {
        _shieldAnimator.SetBool(_shieldAnimBoolName, false);
        PlayShieldDamagedAnim();
    }


}
