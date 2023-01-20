using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnnemyAi : MonoBehaviour
{

    public Transform player;
    private Animator anim;
    Vector3 direction;
    float angle;
    float distance;

    public GameObject hpEnemyBar;
    [SerializeField] private Slider skeletonHpBar;

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
        angle = Vector3.Angle(direction, this.transform.forward) / 2;
        distance = Vector3.Distance(player.position, this.transform.position);

        if (distance < 20 && angle < 60 && skeletonHpBar.value > 0) //distance entre le player et l'ennemi
        {

            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("IsIdle", false);

            if (direction.magnitude > 10) //magnitude = length
            {
                this.transform.Translate(0, 0, 0.1f);
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

        if (skeletonHpBar.value <= 0)
        {
            hpEnemyBar.SetActive(false);
        }
    }


}
