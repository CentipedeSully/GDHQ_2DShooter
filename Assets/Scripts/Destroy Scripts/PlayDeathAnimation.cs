using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDeathAnimation : MonoBehaviour
{
    //Declarations
    [SerializeField] private string _triggerParamName = "OnDeath";
    private Animator _animatorReference;
    


    //Monobehaviors
    private void Awake()
    {
        _animatorReference = GetComponent<Animator>();
    }



    //Utilities
    public void TriggerDeathAnim()
    {
        _animatorReference.SetTrigger(_triggerParamName);
    }

    public void TriggerDeathAnim(string objectTag)
    {
        _animatorReference.SetTrigger(_triggerParamName);
    }

}
