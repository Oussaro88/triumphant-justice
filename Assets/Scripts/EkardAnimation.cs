using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EkardAnimation : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator.GetComponent<Animator>(); //Aassocie la variable au paramètre Animator dans Unity 
    }

    // Update is called once per frame
    void Update()
    {
        //Move Up
        if(Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right")) //si le joueur appuie sur la touche w
        {
            animator.SetBool("IsRunning", true); //la booléene isRunning s'active
        }
        else if(Input.anyKey == false)
        {
            animator.SetBool("IsRunning", false); //la booléene isRunning s'annule
        }

        //Attack Move
        //if(Input.GetButton("Fire1"))
        //if(Input.GetButton("left ctrl"))
        if(Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("IsAttacking", true); //la booléene isAttacking s'active
            Debug.Log("Sword animation");
        }
        else if (Input.anyKey == false)
        {
            animator.SetBool("IsAttacking", false); //la booléene isAttacking s'annule
        }
    }
}
