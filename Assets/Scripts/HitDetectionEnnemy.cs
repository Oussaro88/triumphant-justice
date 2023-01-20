using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDetectionEnnemy : MonoBehaviour
{
    public Slider healthBar;
    private float enemyHp = 100;
    public Animator animator;
    public AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
            healthBar.value -= 10;
            enemyHp = healthBar.value;
    }


    // Start is called before the first frame update
    void Start()
    {

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
