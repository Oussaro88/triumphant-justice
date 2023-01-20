using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDetection : MonoBehaviour
{
    public Slider healthBar;
    public Text hpText;
    private float playerHp;
    public Animator animator;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioSource audio;
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemyWeapon")
        {
            healthBar.value -= 10;
            playerHp = healthBar.value;
            hpText.text = "HP:" + playerHp.ToString() + "/200";
            Debug.Log("Hit");
        }
        else
        {
            return;
        }
        
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(healthBar.value <= 0)
        {
            animator.SetBool("IsDefeated", true);
            gameOverScreen.SetActive(true);
            audio.Stop();

            Cursor.lockState = CursorLockMode.None; //deverrouille le curseur au gameover
            Cursor.visible = true; //reaffiche le curseur au gameover
        }
    }
}
