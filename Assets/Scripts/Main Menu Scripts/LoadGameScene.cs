using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScene : MonoBehaviour
{
    //Declarations
    [SerializeField] private int _sceneIndex = 1;


    //Monobehaviors
    //...


    //Utilites
    public void LoadScene()
    {
        SceneManager.LoadScene(_sceneIndex);
    }


}
