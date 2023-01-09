using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableColliders : MonoBehaviour
{
    //Declarations
    //...


    //Monobehaviors
    //...


    //Utilites
    public void DisableAllColliders()
    {
        if (GetComponent<Collider2D>() != null)
            GetComponent<Collider2D>().enabled = false;
    }

    public void DisableAllColliders(string objectTag)
    {
        if (GetComponent<Collider2D>() != null)
            GetComponent<Collider2D>().enabled = false;
    }

}
