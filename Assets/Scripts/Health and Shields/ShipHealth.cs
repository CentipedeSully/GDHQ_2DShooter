using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipHealth : MonoBehaviour
{
    //Declarations
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
    private LivesController _livesControllerReference;


    //Monobhevaiors
    private void Awake()
    {
        _shipShieldsReference = GetComponent<ShipShieldsController>();
        _livesControllerReference = GameObject.Find("Lives Display").GetComponent<LivesController>();
    }

    private void Start()
    {
        ReportPlayerHealthToLivesControllerUI();
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
        GetComponent<ShipDeathReporter>().ReportDeath();
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
                ReportPlayerHealthToLivesControllerUI();
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

    private void ReportPlayerHealthToLivesControllerUI()
    {
        if (tag == "Player")
            _livesControllerReference.SetImage(_health);
    }

}
