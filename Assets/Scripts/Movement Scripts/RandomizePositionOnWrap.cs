using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizePositionOnWrap : MonoBehaviour
{
    //Declarations
    


    //Monobehaviors



    //Utilites
    public void TeleportToRandomPositionX(float minRange, float maxRange)
    {
        transform.position = new Vector3(Random.Range(minRange, maxRange), transform.position.y, transform.position.z);
    }


}
