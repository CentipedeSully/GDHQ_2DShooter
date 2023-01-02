using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Declarations
    [SerializeField] private float _xPositionMin = -20;
    [SerializeField] private float _xPositionMax = 20;
    [SerializeField] private float _yPosition;
    [SerializeField] private float _zPosition;
    [SerializeField] private List<GameObject> _prefabs;
    [SerializeField] private Transform _prefabContainer;
    [Tooltip("The range that determines when to spawn the object")]
    [SerializeField] private Vector2 _spawnDelayRange;
    [SerializeField] private bool _isSpawning = false;
    [SerializeField] private bool _isPlayerAlive = true;



    //Monobehaviors
    private void Start()
    {
        StartCoroutine(SpawnObjectsUntilPlayerIsDead());
    }



    //Utilites
    private IEnumerator SpawnObjectsUntilPlayerIsDead()
    {
        _isSpawning = true;

        while (_isPlayerAlive)
        {
            yield return new WaitForSeconds(CalculateRandomSpawnDelay());
            Instantiate(GetRandomPrefab(), CalculateSpawnPosition(), Quaternion.identity, _prefabContainer);
        }

        _isSpawning = false;
    }

    private GameObject GetRandomPrefab()
    {
        return _prefabs[Random.Range(0, _prefabs.Count)];
    }

    private Vector3 CalculateSpawnPosition()
    {
        return new Vector3(Random.Range(_xPositionMin, _xPositionMax), _yPosition, _zPosition);
    }

    private float CalculateRandomSpawnDelay()
    {
        return Random.Range(_spawnDelayRange.x, _spawnDelayRange.y);
    }

}
