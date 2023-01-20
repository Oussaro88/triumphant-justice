using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDetectionOgre : MonoBehaviour
{
    public Slider healthBar; //référence au slider
    private float OgreHp = 300;
    public Animator animator; //référence à l'animator
    public AudioSource audio; //référence à l'audioSource

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playerWeapon")
        {
            healthBar.value -= 20; //diminue la barre a chaque contact
            OgreHp = healthBar.value;
            Debug.Log("Hit");
        }
        else
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBar.value <= 0) 
        {
            animator.SetBool("IsDefeated", true);
            audio.Stop();
        }
    }
}
