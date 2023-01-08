using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipDeathReporter : MonoBehaviour
{
    //Declarations
    [SerializeField] private string _gameUtilityName = "Game Utilities";
    [SerializeField] private int _pointValue;
    private GameObject _gameUtilityReference;
    private EnemySpawner _enemySpawnerReference;
    private UIManager _uiManagerReference;

    //Monobehaviors
    private void Awake()
    {
        _gameUtilityReference = GameObject.Find(_gameUtilityName);
        _enemySpawnerReference = _gameUtilityReference.GetComponent<EnemySpawner>();
        _uiManagerReference = _gameUtilityReference.GetComponent<UIManager>();
    }


    //Utilities
    public void ReportDeath()
    {
        if (tag == "Player")
        {
            _enemySpawnerReference.SetIsPlayerAlive(false);
            GameObject.Find("Game Over Display").GetComponent<GameOverDisplayController>().ShowGameOverDisplay();
        }
            

        else if (tag == "Enemy")
        {
            _enemySpawnerReference.DecrementInstanceCount();
            _uiManagerReference.AddPoints(_pointValue);
        }
            
    }
}
