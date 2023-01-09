using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : MonoBehaviour
{
    //Declarations
    [SerializeField] private string _gameUtilitesName = "Game Utilities";
    private GameObject _gameUtilitesObject;
    private EnemySpawner _enemySpawnerReference;
    private Spawner _otherSpawnerReference;


    //Monobehaviors
    private void Awake()
    {
        _gameUtilitesObject = GameObject.Find(_gameUtilitesName);

        if (_gameUtilitesObject != null)
        {
            _enemySpawnerReference = _gameUtilitesObject.GetComponent<EnemySpawner>();
            _otherSpawnerReference = _gameUtilitesObject.GetComponent<Spawner>();
        }
    }


    //Utilites
    public void ActivateSpawners()
    {
        _enemySpawnerReference.StartSpawning();
        _otherSpawnerReference.StartSpawning();
    }

    public void ActivateSpawners(string objectTag)
    {
        ActivateSpawners();
    }

}
