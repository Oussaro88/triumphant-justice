using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDetectionLevel2 : MonoBehaviour
{
    public Slider healthBar; //référence au slider
    public Text hpText; //référence au text du slider
    private float playerHp;
    public Animator animator; //référence à l'animator
    [SerializeField] private GameObject gameOverScreen; //référence au gameOverScreen
    [SerializeField] private AudioSource audio; //référence à l'audioSource

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemyWeapon")
        {
            healthBar.value -= 10; //barre de vie diminie à chaque contact
            playerHp = healthBar.value;
            hpText.text = "HP:" + playerHp.ToString() + "/300";
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
