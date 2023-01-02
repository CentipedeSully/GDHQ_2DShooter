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
    public UnityEvent<GameObject> OnObjectDisabled;


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
        OnObjectDisabled?.Invoke(gameObject);
        OnObjectDisabled.RemoveAllListeners();
    }

    private void SubscribeSpawnersToThisScript()
    {
        if (tag == "Player")
        {
            OnObjectDisabled.AddListener(_gameUtilitiesReference.GetComponent<EnemySpawner>().ReportShipDeath);
            OnObjectDisabled.AddListener(_gameUtilitiesReference.GetComponent<Spawner>().ReportPlayerDeath);
        }

        else if (tag == "Enemy")
        {
            OnObjectDisabled.AddListener(_gameUtilitiesReference.GetComponent<EnemySpawner>().ReportShipDeath);
        }
    }

}
