using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPowerup : MonoBehaviour
{
    //Declarations
    [Tooltip("0 == TripleShot, 1 == Speed, 2 == Shields")]
    [SerializeField][Range(0,2)] private int _powerupId = 0;
    [SerializeField] private string _playerTag = "Player";

    //Monobehaviors
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _playerTag)
        {
            EnablePowerUp(collision.gameObject);
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
