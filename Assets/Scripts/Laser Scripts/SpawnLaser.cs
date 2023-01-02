using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLaser : MonoBehaviour
{
    //Declarations
    [SerializeField] private Transform _spawnLocation;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private GameObject _tripleShotPrefab;
    [SerializeField] private List<string> _hostileTags;
    [SerializeField] private string _laserContainerName = "Laser Container";
    private Transform _laserContainer;



    //Monobehaviors
    private void Awake()
    {
        SetupLaserContainer();
    }



    //Utilities
    private void SetupLaserContainer()
    {
        if (_laserContainer == null)
            _laserContainer = GameObject.Find(_laserContainerName).transform;
    }

    public void CreateLaser(Vector3 direction)
    {
        GameObject newLaser = Instantiate(_laserPrefab, _spawnLocation.position, _laserPrefab.transform.rotation, _laserContainer);
        newLaser.GetComponent<LaserCollisionBehavior>().SetHostileTags(_hostileTags);
        //newLaser.GetComponent<MoveObject>().SetDirection(direction);
    }

    public void CreateTripleLaser(Vector3 direction)
    {
        GameObject newTripleLaser = Instantiate(_tripleShotPrefab, _spawnLocation.position, _laserPrefab.transform.rotation, _laserContainer);

        for (int childIndex = 0; childIndex < newTripleLaser.transform.childCount; childIndex++)
        {
            newTripleLaser.transform.GetChild(childIndex).GetComponent<LaserCollisionBehavior>().SetHostileTags(_hostileTags);
        }
    }

}
