using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDetectionBoss : MonoBehaviour
{
    public Slider healthBar; //reférence au slider
    private float BossHp = 300;
    public Animator animator; //référence a l'animator
    public AudioSource audio; //référence à l'audio source

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playerWeapon")
        {
            healthBar.value -= 20; //diminue la barre a chaque contact
            BossHp = healthBar.value;
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
