using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    //Declarations
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score = 0;


    //Monobehaviors
    private void Start()
    {
        UpdateScore();
    }


    //Utilities
    private void UpdateScore()
    {
        _scoreText.text = "Score: " + _score;
    }

    public void AddPoints(int value)
    {
        _score += value;
        UpdateScore(); 
    }



}
