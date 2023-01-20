using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDetectionLevel4 : MonoBehaviour
{
    public Slider healthBar; //barre de vie
    public Text hpText; //texte du slider
    private float playerHp;
    public Animator animator; //animator
    [SerializeField] private GameObject gameOverScreen; //écran gameOver
    [SerializeField] private AudioSource audio; //référence à l'audioSource

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemyWeapon")
        {
            healthBar.value -= 10; //barre de vie diminiue à chaque contact avec le weapon de l'ennemi
            playerHp = healthBar.value;
            hpText.text = "HP:" + playerHp.ToString() + "/600";
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
            gameOverScreen.SetActive(true);// le player est GameoVer
            audio.Stop();

            Cursor.lockState = CursorLockMode.None; //deverrouille le curseur au gameover
            Cursor.visible = true; //reaffiche le curseur au gameover
        }
    }
}
