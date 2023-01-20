using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeAudio : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer; //Référence à mon audioMixer
    [SerializeField] private string nameParam; //Nom du parametre dans mon audioMixer
    [SerializeField] private Slider slider; //Référence au slider

    public void SetVolume(float volume)
    {
        volume = slider.value;
        audioMixer.SetFloat(nameParam, volume); //Attribue a la valeur nameParam la valeur de la variable volume
    }
}
