using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTreasureFinalLevel : MonoBehaviour
{
    [SerializeField] private GameObject finalScreen;
    [SerializeField] private GameObject miniMap;
    [SerializeField] private AudioSource[] sounds;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private void OnTriggerEnter(Collider other)
    {
        miniMap.SetActive(false);
        finalScreen.SetActive(true);
        audioSource.PlayOneShot(audioClip);
        foreach (AudioSource audioSource in sounds)
        {
            audioSource.Stop();
        }
    }


    void Awake()
    {
        finalScreen.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
