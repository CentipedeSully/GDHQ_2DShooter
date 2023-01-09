using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableStartText : MonoBehaviour
{
    //Declarations
    [SerializeField] private GameObject _textGameObject;


    //Monobehaviors
    //...


    //Utilities
    public void DisableText()
    {
        _textGameObject.SetActive(false);
    }

    public void DisableText(string objectTag)
    {
        DisableText();
    }


}
