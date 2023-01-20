using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDetectionDemonGirl : MonoBehaviour
{
    public Slider healthBar;
    private float demonGirlHp = 300;
    public Animator animator;
    public AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "playerWeapon")
        {
            healthBar.value -= 20; //diminie la barre de vie à chaque contact
            demonGirlHp = healthBar.value;
            Debug.Log("Hit");
        }
        else { return; }
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
