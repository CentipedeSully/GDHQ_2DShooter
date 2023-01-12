using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplicationOnInput : MonoBehaviour
{
    //Declarations
    [SerializeField] private bool _isDebugModeEnabled = false;


    //Monobehaviors
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (_isDebugModeEnabled)
                Debug.Log("Quit Input Detected");
            Application.Quit();
        }
    }


    //Uitlites
    //...


}
