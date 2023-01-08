using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesController : MonoBehaviour
{
    //Delcarations
    [SerializeField] private GameObject _threeLives;
    [SerializeField] private GameObject _twoLives;
    [SerializeField] private GameObject _oneLives;
    [SerializeField] private GameObject _zeroLives;


    //Monobehaviors
    //...


    //Utilites
    private void DisableAllImages()
    {
        _threeLives.SetActive(false);
        _twoLives.SetActive(false);
        _oneLives.SetActive(false);
        _zeroLives.SetActive(false);
    }

    public void SetImage(int currentLife)
    {
        switch(currentLife)
        {
            case 3:
                DisableAllImages();
                _threeLives.SetActive(true);
                break;

            case 2:
                DisableAllImages();
                _twoLives.SetActive(true);
                break;

            case 1:
                DisableAllImages();
                _oneLives.SetActive(true);
                break;

            case 0:
                DisableAllImages();
                _zeroLives.SetActive(true);
                break;
        }
    }

}
