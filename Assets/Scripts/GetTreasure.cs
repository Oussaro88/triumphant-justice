using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTreasure : MonoBehaviour
{
    [SerializeField] private GameObject winScreen; //référence au Win Screen
    [SerializeField] private GameObject miniMap; //référence a la minimap
    [SerializeField] private AudioSource[] sounds; //référence aux audiosouces
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private void OnTriggerEnter(Collider other) //au contact avec le trésor
    {
        miniMap.SetActive(false);
        winScreen.SetActive(true); // le niveau est fini
        audioSource.PlayOneShot(audioClip);
        foreach(AudioSource audioSource in sounds)
        {
            audioSource.Stop();
        }
    }


    void Awake()
    {
        winScreen.SetActive(false);
    }

}
