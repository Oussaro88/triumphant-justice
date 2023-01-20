using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDetectionLevel3 : MonoBehaviour
{
    public Slider healthBar; //référence à la barre de vie
    public Text hpText; //référence au texte du slider
    private float playerHp;
    public Animator animator; //référence à l'animator
    [SerializeField] private GameObject gameOverScreen; //écran GameOver
    [SerializeField] private AudioSource audio; //référence à l'audioSource

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemyWeapon")
        {
            healthBar.value -= 10; //diminiue la barre de vie à chaque coup
            playerHp = healthBar.value;
            hpText.text = "HP:" + playerHp.ToString() + "/400";
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
            gameOverScreen.SetActive(true); //le joueur est GameOver
            audio.Stop();

            Cursor.lockState = CursorLockMode.None; //deverrouille le curseur au gameover
            Cursor.visible = true; //reaffiche le curseur au gameover
        }
    }
}
