using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LittleDevilAI : MonoBehaviour
{
    public Transform player;
    private Animator anim;
    private Vector3 direction;
    private float angle;
    private float distance;
    [SerializeField] private Slider lDevilHpBar; //référence à la valeur du slider

    public GameObject hpEnemyBar; //référence à la barre de vie Ui

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        hpEnemyBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.position - this.transform.position;
        angle = Vector3.Angle(direction, this.transform.forward);
        distance = Vector3.Distance(player.position, this.transform.position);

        if (distance < 50 && angle < 60 && lDevilHpBar.value > 0) //distance entre le player et l'ennemi + //Applique les instructions uniquement quand l'enemi est encore vivant
        {

            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("IsIdle", false);

            if (direction.magnitude > 10) //magnitude = length
            {
                this.transform.Translate(0, 0, 0.4f);
                anim.SetBool("IsFlying", true);
                anim.SetBool("IsAttacking", false);
            }
            else
            {
                anim.SetBool("IsAttacking", true);
                anim.SetBool("IsFlying", false);
            }
        }
        else
        {

            anim.SetBool("IsIdle", true);
            anim.SetBool("IsFlying", false);
            anim.SetBool("IsAttacking", false);
        }



        if (Vector3.Distance(player.position, this.transform.position) < 40)
        {
            hpEnemyBar.SetActive(true);
        }
        else
        {
            hpEnemyBar.SetActive(false);
        }

        if (lDevilHpBar.value <= 0)
        {
            hpEnemyBar.SetActive(false);
        }
    }
}
