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
    [SerializeField] private string _laserSoundObjectName = "Laser Shot Sound";
    [SerializeField] private string _TripleShotSoundObjectName = "TripleShot Sound";
    private AudioSource _laserSoundEffectReference;
    private AudioSource _tripleShotSoundEffectReference;



    //Monobehaviors
    private void Awake()
    {
        SetupLaserContainer();
        SetupSoundEffectReference();
    }



    //Utilities
    private void SetupLaserContainer()
    {
        if (_laserContainer == null)
            _laserContainer = GameObject.Find(_laserContainerName).transform;
    }

    private void SetupSoundEffectReference()
    {
        _laserSoundEffectReference = GameObject.Find(_laserSoundObjectName).GetComponent<AudioSource>();
        _tripleShotSoundEffectReference = GameObject.Find(_TripleShotSoundObjectName).GetComponent<AudioSource>();
    }

    public void CreateLaser(Vector3 direction)
    {
        GameObject newLaser = Instantiate(_laserPrefab, _spawnLocation.position, _laserPrefab.transform.rotation, _laserContainer);
        newLaser.GetComponent<LaserCollisionBehavior>().SetHostileTags(_hostileTags);
        //newLaser.GetComponent<MoveObject>().SetDirection(direction);

        _laserSoundEffectReference.Play();


    }

    public void CreateTripleLaser(Vector3 direction)
    {
        GameObject newTripleLaser = Instantiate(_tripleShotPrefab, _spawnLocation.position, _laserPrefab.transform.rotation, _laserContainer);

        for (int childIndex = 0; childIndex < newTripleLaser.transform.childCount; childIndex++)
        {
            newTripleLaser.transform.GetChild(childIndex).GetComponent<LaserCollisionBehavior>().SetHostileTags(_hostileTags);
            _tripleShotSoundEffectReference.Play();
        }

        //_tripleShotSoundEffectReference.Play();
    }

}
