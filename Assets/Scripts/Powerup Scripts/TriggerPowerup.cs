using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPowerup : MonoBehaviour
{
    //Declarations
    [Tooltip("0 == TripleShot, 1 == Speed, 2 == Shields")]
    [SerializeField][Range(0,2)] private int _powerupId = 0;
    [SerializeField] private string _playerTag = "Player";
    [SerializeField] private string _powerupSoundObjectName = "Powerup Sound";
    private AudioSource _powerupAudioClip;


    //Monobehaviors
    private void Awake()
    {
        _powerupAudioClip = GameObject.Find(_powerupSoundObjectName).GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _playerTag)
        {
            EnablePowerUp(collision.gameObject);
            _powerupAudioClip.Play();
            Destroy(gameObject);
        }
    }


    //Utilties
    private void EnablePowerUp(GameObject _playerObject)
    {
        switch (_powerupId)
        {
            case 0:
                _playerObject.GetComponent<TripleShotToggler>().EnableTripleShot();
                break;
            case 1:
                _playerObject.GetComponent<SpeedBooster>().EnableSpeedBoost();
                break;
            case 2:
                _playerObject.GetComponent<ShipShieldsController>().GainShields();
                break;
        }
    }

}
