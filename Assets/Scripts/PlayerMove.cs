using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private CharacterController ekard;
    private Vector3 playerMove; // Déplacement du joueur
    private float hAxis = 0f; //mouvement horizontal
    private float vAxis = 0f; //mouvement vertical
    private float moveAngle = 0; //l'angle de mouvement du personnage
    private float lookAngle = 0; //angle d'orientation du joueur
    [SerializeField] private float gravity = -10; //Gravité
    private float newY;

    //Input et animation
    private bool attack = false; //est-ce que j'attaque
    private bool isMoving = false; //est-ce que je bouge

    //animation
    public Animator animator;


    public void OnMove(InputAction.CallbackContext context)
    {
        playerMove = context.ReadValue<Vector2>();
        hAxis = playerMove.x;
        vAxis = playerMove.y;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        attack = context.performed; //attack = true
    }

    // Start is called before the first frame update
    void Start()
    {
        ekard = GetComponent<CharacterController>(); //Cache le character controller et me donne un visuel sur le component séléctionné dans l'inspecteur
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //paramètres de déplacements de mon personnage
        playerMove = new Vector3(hAxis, 0f, vAxis);
        moveAngle = (Mathf.Atan2(playerMove.x, playerMove.z) * Mathf.Rad2Deg); //on calcule l'angle de muouvement et on le convertit en degré et le rendre relatif a langle de la caméra
        lookAngle = Mathf.LerpAngle(transform.eulerAngles.y, moveAngle, 0.25f); //Progressivement me tourner vers l'angle de déplacement


        if (playerMove.magnitude >= 0.1f) //on change d'angle seulement quand on bouge
        {
            transform.rotation = Quaternion.Euler(0, lookAngle, 0); //tourne le transform sur l'axe des y
            Vector3 forward = Vector3.forward * playerMove.magnitude; //trouve le devant du joueur selon son orientation
            playerMove = Quaternion.Euler(0f, moveAngle, 0f) * forward; //transposer la force avec le mouvement de l'angle
            isMoving = true;
        }
        else { isMoving = false; }

        playerMove.y -= gravity * Time.deltaTime; //Applique la gravité 
        ekard.Move(playerMove); //le joueur bouge selon les paramaetres du vecteur playerMove

        if (isMoving)
        {
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsRunning", true); //la booléene isRunning s'active                   
        }
        else if (!isMoving)
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsIdle", true);
        }

        //Attack animation
        if (attack)
        {
            animator.SetTrigger("Attacking");
            animator.SetBool("IsIdle", false);
        }
    }
}
