using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrollAi : MonoBehaviour
{
    public Transform player; //référence au Transform
    private Animator anim; //référence à l'animator
    private Vector3 direction; //référence à la direction du transform
    private float angle;
    private float distance;
    [SerializeField] private Slider trollHpBar; //référence à la valeur du slider

    public GameObject hpEnemyBar; //référence à la barre de vie Ui

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); //cache le component Animator
        hpEnemyBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.position - this.transform.position; //établit la direction du transform
        angle = Vector3.Angle(direction, this.transform.forward); //établit le devant du transform et sa destination
        distance = Vector3.Distance(player.position, this.transform.position); //reférence à la distance entre le tranform et sa destination

        if (distance < 50 && angle < 60 && trollHpBar.value > 0) //distance entre le player et l'ennemi + Applique les instructions uniquement quand l'enemi est encore vivant
        {

            direction.y = 0; //fixe le mouvement en y
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f); //orientation du transform

            anim.SetBool("IsIdle", false);

            if (direction.magnitude > 10) //magnitude = length
            {
                this.transform.Translate(0, 0, 0.4f);
                anim.SetBool("IsRunning", true);
                anim.SetBool("IsAttacking", false);
            }
            else
            {
                anim.SetBool("IsAttacking", true);
                anim.SetBool("IsRunning", false);
            }
        }
        else
        {

            anim.SetBool("IsIdle", true);
            anim.SetBool("IsRunning", false);
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

        if(trollHpBar.value <= 0)
        {
            hpEnemyBar.SetActive(false);
        }
    }
}
