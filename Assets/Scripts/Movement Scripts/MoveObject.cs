using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveObject : MonoBehaviour
{
    //Declarations
    [SerializeField] private float _speed = 0;
    [SerializeField] private Vector3 _direction = Vector3.zero;

    [SerializeField] private bool _isHorizontalWrapEnabled = false;
    [SerializeField] private bool _isVerticalWrapEnabled = false;

    [SerializeField] private float _leftBound = -21.6f;
    [SerializeField] private float _rightBound = 21.6f;
    [SerializeField] private float _bottomBound = -12.5f;
    [SerializeField] private float _upperBound = 12.5f;

    public UnityEvent<float,float> OnVerticalWrap;


    //Monobehaviors
    private void Update()
    {
        BoundHorizontalMovement();
        BoundVerticalMovement();
    }



    //Utilites
    public void BoundHorizontalMovement()
    {
        Vector3 horizontalMoveVector = new Vector3(_direction.x, 0, 0);

        //Move horizontally if within the bounds
        if ( (_direction.x > 0 && transform.position.x < _rightBound) || (_direction.x < 0 && transform.position.x > _leftBound) )
            MoveViaTranslate(horizontalMoveVector);

        //
        else if (_direction.x < 0 && transform.position.x <= _leftBound)
        {
            if (_isHorizontalWrapEnabled)
            {
                TeleportToRightBound();
                MoveViaTranslate(horizontalMoveVector);
            }
        }

        else if (_direction.x > 0 && transform.position.x >= _rightBound)
        {
            if (_isHorizontalWrapEnabled)
            {
                TeleportToLeftBound();
                MoveViaTranslate(horizontalMoveVector);
            }
        }
    }

    public void BoundVerticalMovement()
    {
        Vector3 verticalMoveVector = new Vector3(0, _direction.y, 0);

        //Move vertically if within the bounds
        if ( (_direction.y > 0 && transform.position.y < _upperBound) || (_direction.y < 0 && transform.position.y > _bottomBound) )
            MoveViaTranslate(verticalMoveVector);

        else if (_direction.y < 0 && transform.position.y <= _bottomBound)
        {
            if (_isVerticalWrapEnabled)
            {
                TeleportToUpperBound();
                InvokeVerticalWrapEvent();
                MoveViaTranslate(verticalMoveVector);

            }
        }

        else if (_direction.y > 0 && transform.position.y >= _upperBound)
        {
            if (_isVerticalWrapEnabled)
            {
                TeleportToBottomBound();
                MoveViaTranslate(verticalMoveVector);
            }
        }
    }

    private void MoveViaTranslate(Vector3 move)
    {
        transform.Translate(move * _speed * Time.deltaTime, Space.World);
    }

    private void InvokeVerticalWrapEvent()
    {
        OnVerticalWrap?.Invoke(_leftBound, _rightBound);
    }

    private void TeleportToRightBound()
    {
        transform.position = new Vector3(_rightBound, transform.position.y, transform.position.z);
    }

    private void TeleportToLeftBound()
    {
        transform.position = new Vector3(_leftBound, transform.position.y, transform.position.z);
    }

    private void TeleportToUpperBound()
    {
        transform.position = new Vector3(transform.position.x, _upperBound, transform.position.z);
    }

    private void TeleportToBottomBound()
    {
        transform.position = new Vector3(transform.position.x, _bottomBound, transform.position.z);
    }


    public void SetDirection(Vector3 newDirection)
    {
        _direction = newDirection;
    }

    public Vector3 GetDirection()
    {
        return _direction;
    }

    public void SetSpeed(float newValue)
    {
        _speed = newValue;
    }

    public float GetSpeed()
    {
        return _speed;
    }

    public void SetVerticalWrap(bool newValue)
    {
        _isVerticalWrapEnabled = newValue;
    }

    public void SetHorizontalWrap(bool newValue)
    {
        _isHorizontalWrapEnabled = newValue;
    }

}
