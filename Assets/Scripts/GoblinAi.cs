using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinAi : MonoBehaviour
{
    public Transform player;
    static Animator anim;
    public GameObject hpBar;
    [SerializeField] private Slider goblinHpBar;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        hpBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);

        if (Vector3.Distance(player.position, this.transform.position) < 30 && angle < 35 && goblinHpBar.value > 0) //distance entre le player et l'ennemi
        {
            
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("IsIdle", false);

            if (direction.magnitude > 10) //magnitude = length
            {
                this.transform.Translate(0, 0, 0.3f);
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
            hpBar.SetActive(true);
        }
        else
        {
            hpBar.SetActive(false);
        }

        if (goblinHpBar.value <= 0)
        {
            hpBar.SetActive(false);
        }
    }
}
