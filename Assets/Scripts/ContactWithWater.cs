using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactWithWater : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") //Si le player entre en contact avec l'eau
        {
            gameOverScreen.SetActive(true); //le player est GameOver
            audio.Stop();
        }
    }
}
