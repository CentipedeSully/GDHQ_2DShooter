using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableScreenWrapping : MonoBehaviour
{
    //Declarations
    //...

    //Monobehaviors
    //...

    //Utilites
    public void DisableWrapping()
    {
        GetComponent<MoveObject>().SetHorizontalWrap(false);
        GetComponent<MoveObject>().SetVerticalWrap(false);
    }

    public void DisableWrapping(string objectTag)
    {
        DisableWrapping();
    }

}
