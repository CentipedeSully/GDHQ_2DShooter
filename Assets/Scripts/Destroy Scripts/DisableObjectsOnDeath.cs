using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjectsOnDeath : MonoBehaviour
{
    //Declarations
    [SerializeField] private List<GameObject> _gameobjects;


    //monobehaviors
    //...


    //Utilites
    public void DisableObjects()
    {
        foreach (GameObject element in _gameobjects)
            element.SetActive(false);
    }


    public void DisableObjects(string objectTag)
    {
        DisableObjects();
    }
        



}
