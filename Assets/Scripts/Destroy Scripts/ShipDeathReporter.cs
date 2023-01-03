using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipDeathReporter : MonoBehaviour
{
    //Declarations
    [SerializeField] private string _gameUtilitiesName = "Game Utilities";
    private GameObject _gameUtilitiesReference;
    [HideInInspector]
    public UnityEvent<GameObject> OnObjectDestroyed;


    //Monobehaviors
    private void Awake()
    {
        _gameUtilitiesReference = GameObject.Find(_gameUtilitiesName);
    }

    private void Start()
    {
        SubscribeSpawnersToThisScript();
    }


    //Utilities
    public void ReportDeath()
    {
        OnObjectDestroyed?.Invoke(gameObject);
        OnObjectDestroyed.RemoveAllListeners();
    }

    private void SubscribeSpawnersToThisScript()
    {
        if (tag == "Player")
        {
            OnObjectDestroyed.AddListener(_gameUtilitiesReference.GetComponent<EnemySpawner>().ReportShipDeath);
            OnObjectDestroyed.AddListener(_gameUtilitiesReference.GetComponent<Spawner>().ReportPlayerDeath);
        }

        else if (tag == "Enemy")
        {
            OnObjectDestroyed.AddListener(_gameUtilitiesReference.GetComponent<EnemySpawner>().ReportShipDeath);
        }
    }

}
