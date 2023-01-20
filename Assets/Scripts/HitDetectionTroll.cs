using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDetectionTroll : MonoBehaviour
{
    public Slider healthBar; ////Référence au slider
    private float enemyHp = 100; //Point HP du troll
    public Animator animator; //Référence à l'animator
    public AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "playerWeapon")
        {
            healthBar.value -= 10; //Apres chaque coup recu, le troll perd 10 points
            enemyHp = healthBar.value; //les coups encaissés sont retranchés de la valeur initiale des points HP
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
            animator.SetTrigger("IsDefeated");
            audio.Stop();
        }
    }
}
