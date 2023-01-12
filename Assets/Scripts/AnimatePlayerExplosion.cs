using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlayerExplosion : MonoBehaviour
{
    //Declarations
    [SerializeField] private string _triggerParamName = "OnDeath";
    private Animator _animatorReference;


    //Monobehaviors
    private void Awake()
    {
        _animatorReference = GetComponent<Animator>();
    }


    //Utilites
    public void AnimateDeath()
    {
        _animatorReference.SetTrigger(_triggerParamName);
    }

    public void AnimateDeath(string objectTag)
    {
        AnimateDeath();
    }

}
