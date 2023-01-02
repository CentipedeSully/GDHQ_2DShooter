using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterLifespan : MonoBehaviour
{
    //Declarations
    [SerializeField] private float _lifespan = 8;
    private float _currentLifespan = 0;


    //Monbehaviors
    private void Update()
    {
        //Just Destroy lasers if they're off screen. No Need for them to sustain themselves when offscreen.
        CountLifespan();
    }


    //Utilities
    private void CountLifespan()
    {
        if (_currentLifespan < _lifespan)
            _currentLifespan += Time.deltaTime;
        else
            Destroy(gameObject);
    }



}
