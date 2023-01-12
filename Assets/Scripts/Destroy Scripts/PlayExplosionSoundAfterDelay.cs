using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayExplosionSoundAfterDelay : MonoBehaviour
{
    //Declarations
    [SerializeField] private float _explosionSoundDelay = .15f;
    [SerializeField] private string _ExplosionSoundObjectName = "Explosion Sound";
    private AudioSource _explosionAudioSourceReference;

    //Monobehaviors
    private void Awake()
    {
        _explosionAudioSourceReference = GameObject.Find(_ExplosionSoundObjectName).GetComponent<AudioSource>();
    }


    //Utilites
    private void PlaySoundEffect()
    {
        _explosionAudioSourceReference.Play();
    }

    public void PlaySoundAfterDelay()
    {
        Invoke("PlaySoundEffect", _explosionSoundDelay);
    }

    public void PlaySoundAfterDelay(string objectTag)
    {
        PlaySoundAfterDelay();
    }
}
