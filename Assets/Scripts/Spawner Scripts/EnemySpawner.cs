using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Declarations
    [Header("Spawn Position Utilities")]
    [SerializeField] private float _minBoundsX = -20;
    [SerializeField] private float _maxBoundsX = 20;
    [SerializeField] private float _zPosition = 0;
    [SerializeField] private float _yPosition = 0;
    [SerializeField] private Transform _enemyContainer;
    private GameObject _newSpawnedEnemy;

    [Header("Spawner Settings")]
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnDelay = 2;
    private WaitForSeconds _spawnDelayTimer;
    [SerializeField] private int _maxEnemyCount = 8;
    [SerializeField] private int _currentEnemyCount = 0;
    [SerializeField] private bool _isSpawning = false;
    [SerializeField] private bool _isPlayerAlive = true;




    //Monobehaviors
    //...


    //Utilities
    public void SetIsPlayerAlive(bool newValue)
    {
        _isPlayerAlive = newValue;
    }

    public bool IsPlayerAlive()
    {
        return _isPlayerAlive;
    }

    public void DecrementInstanceCount()
    {
        _currentEnemyCount--;
    }

    private GameObject SpawnEnemy()
    {
        _newSpawnedEnemy = Instantiate(_enemyPrefab, CalculateRandomSpawnPosition(), Quaternion.identity, _enemyContainer);
        _currentEnemyCount += 1;

        return _newSpawnedEnemy;
    }

    private Vector3 CalculateRandomSpawnPosition()
    {
        return new Vector3(Random.Range(_minBoundsX, _maxBoundsX), _yPosition, _zPosition);
    }

    private IEnumerator EnterSpawning()
    {
        _isSpawning = true;

        while(_isPlayerAlive)
        {
            if (_currentEnemyCount < _maxEnemyCount)
                SpawnEnemy();
            yield return _spawnDelayTimer;
        }

        _isSpawning = false;
    }

    public void StartSpawning()
    {
        _spawnDelayTimer = new WaitForSeconds(_spawnDelay);
        StartCoroutine(EnterSpawning());
    }
}
