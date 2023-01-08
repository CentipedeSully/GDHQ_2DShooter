using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverDisplayController : MonoBehaviour
{
    //Declarations
    [SerializeField] private GameObject _gameOverObject;
    [SerializeField] private string _reloadSceneName = "SpaceShooterGame";
    private bool _isRestartEnabled = false;


    //Monobehaviors
    private void Start()
    {
        HideGameOverDisplay();
    }

    private void Update()
    {
        RestartGameOnCommandIfRestartEnabled();
    }


    //Utilities
    public void ShowGameOverDisplay()
    {
        _gameOverObject.SetActive(true);
        _isRestartEnabled = true;
    }

    public void HideGameOverDisplay()
    {
        _gameOverObject.SetActive(false);
        _isRestartEnabled = false;
    }

    private void RestartGameOnCommandIfRestartEnabled()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isRestartEnabled)
            SceneManager.LoadScene(_reloadSceneName);
    }


}
