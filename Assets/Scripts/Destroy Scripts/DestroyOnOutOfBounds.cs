using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnOutOfBounds : MonoBehaviour
{
    //Declarations
    [SerializeField] private float _leftBound = -22;
    [SerializeField] private float _rightBound = 22;
    [SerializeField] private float _upperBound = 13;
    [SerializeField] private float _lowerBound = -13;


    //Monobehaviors
    private void Update()
    {
        DestroyIfOutOfBounds();
    }


    //Utilities
    private void DestroyIfOutOfBounds()
    {
        if (transform.position.x > _rightBound || transform.position.x < _leftBound)
            Destroy(gameObject);

        if (transform.position.y > _upperBound || transform.position.y < _lowerBound)
            Destroy(gameObject);
    }


}
