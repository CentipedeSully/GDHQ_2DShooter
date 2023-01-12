using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRandomly : MonoBehaviour
{
    //Declarations
    [SerializeField] private float _minShotRate = .5f;
    [SerializeField] private float _maxShotRate = 3f;
    [SerializeField] private float _shotCommandTriggerDuration = .1f;
    private LaserShotController _laserShotControllerRef;



    //Monobehaviors
    private void Awake()
    {
        _laserShotControllerRef = GetComponent<LaserShotController>();
    }

    private void Start()
    {
        StartCoroutine(ShootRandomly());
    }


    //Utilites
    private IEnumerator ShootRandomly()
    {
        yield return new WaitForSeconds(Random.Range(_minShotRate, _maxShotRate));

        //Set and then reset shot command
        _laserShotControllerRef.SetShootCommand(true);
        Invoke("ResetShotCommand", _shotCommandTriggerDuration);
    }

    private void ResetShotCommand()
    {
        _laserShotControllerRef.SetShootCommand(false);
    }

}
