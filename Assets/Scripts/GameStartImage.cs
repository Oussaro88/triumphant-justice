using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartImage : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu; //référence au mainMenu
    [SerializeField] private GameObject startScreen; //référence à l'écran principale du jeu
    [SerializeField] private GameObject menuOptions; //référence au menu Options

    // Start is called before the first frame update
    void Awake()
    {
        startScreen.SetActive(true);
        mainMenu.SetActive(false);
        menuOptions.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            startScreen.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}
