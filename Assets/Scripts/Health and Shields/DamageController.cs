using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    //Declarations
    [SerializeField] private GameObject _damageLv1;
    [SerializeField] private GameObject _damageLv2;


    //Monobehaviors
    private void Start()
    {
        DisableAllDamageLvls();
    }


    //Utilites
    private void DisableAllDamageLvls()
    {
        _damageLv1.SetActive(false);
        _damageLv2.SetActive(false);
    }

    public void UpdateDamageLv(int remainingHealthValue)
    {
        DisableAllDamageLvls();

        switch (remainingHealthValue)
        {
            case 2:
                _damageLv1.SetActive(true);
                break;
            case 1:
                _damageLv1.SetActive(true);
                _damageLv2.SetActive(true);
                break;
            default:
                break;
        }
    }

}
