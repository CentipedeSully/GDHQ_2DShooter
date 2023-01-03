using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollisionBehavior : MonoBehaviour
{
    //Declarations
    [SerializeField] private List<string> _hostileTags;


    //Monobehaviors
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_hostileTags.Contains(collision.tag))
        {
            collision.gameObject.GetComponent<ShipHealth>().DamageHealth();
            Destroy(gameObject);
        }
    }


    //Utilities
    public void SetHostileTags(List<string> tags)
    {
        foreach (string tag in tags)
            _hostileTags.Add(tag);
    }



}
