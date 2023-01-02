using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipHealth : MonoBehaviour
{
    //Declarations
    [Header("Necessary References")]
    [SerializeField] private string _gameUtilitiesObjectName = "Game Utilities";

    [Header("Health Settings")]
    [SerializeField] private int _health = 3;
    [SerializeField] private List<string> _validDamagingTags;

    [Header("Invulnerability Utilities")]
    [SerializeField] private float _invulnerabilityAfterDamageDuration = .5f;
    private float _currentInvulnerabilityDuration = 0;
    [SerializeField] private bool _isInvulnerable = false;

    [Header("Events")]
    public UnityEvent OnShipDamaged;
    public UnityEvent<string> OnShipDestroyed;

    //references
    private ShipShieldsController _shipShieldsReference;


    //Monobhevaiors
    private void Awake()
    {
        _shipShieldsReference = GetComponent<ShipShieldsController>();

        //Subscribe to each ship when the ship spawns via Main Spawner(s), not on ship health ================================================
        OnShipDestroyed.AddListener(GameObject.Find(_gameUtilitiesObjectName).GetComponent<EnemySpawner>().ReportShipDeath);
    }

    private void Update()
    {
        CountInvulnerabilityDuration();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_validDamagingTags.Contains(collision.gameObject.tag))
        {
            if (collision.gameObject.tag == "Enemy")
                collision.gameObject.GetComponent<ShipHealth>().DamageHealth();

            DamageHealth();
        }
    }



    //Utilities
    private void DestroyShip()
    {
        OnShipDestroyed?.Invoke(tag);
        Destroy(gameObject);
    }

    public void DamageHealth(int damage = 1)
    {
        if (!_isInvulnerable)
        {
            if (_shipShieldsReference.IsShieldsActive())
                _shipShieldsReference.DamageShields();

            else
            {
                _health -= damage;
                if (_health <= 0)
                    DestroyShip();
            }

            EnableTemporaryInvulnerability();
        }
    }

    private void CountInvulnerabilityDuration()
    {
        if (_isInvulnerable)
        {
            _currentInvulnerabilityDuration += Time.deltaTime;

            if (_currentInvulnerabilityDuration >= _invulnerabilityAfterDamageDuration)
            {
                _isInvulnerable = false;
                _currentInvulnerabilityDuration = 0;
            }
        }
    }

    private void EnableTemporaryInvulnerability()
    {
        _isInvulnerable = true;
        _currentInvulnerabilityDuration = 0;
    }


}
