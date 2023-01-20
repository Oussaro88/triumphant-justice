using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject menuOptions; //écran options
    [SerializeField] private GameObject mainMenu; //écran menu principal
    [SerializeField] private GameObject loadScreen; //écran de chargement
    [SerializeField] private GameObject howToPlayScreen; //écran comment jouer
    private float loadTime = 5;
    private bool isLoading = false;
    [SerializeField] AudioSource audioS; //mon audio Source

    // Start is called before the first frame update
    void Awake()
    {
        loadScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isLoading)
        {
            float timer = Time.deltaTime;
            loadTime -= timer; //Countdown
            Debug.Log(loadTime);
            if (loadTime <= 0)
            {
                OnLoad();
            }
        }   
    }

    public void StartGame()
    {
        audioS.Stop();
        loadScreen.SetActive(true);
        isLoading = true;
        
    }

    public void QuitGame()
    {
        Application.Quit(); //Quitte l'application
    }

    public void OptionsMenu()
    {
        menuOptions.SetActive(true);
    }

    public void HowToPlayMenu()
    {
        howToPlayScreen.SetActive(true);
    }

    public void ReturnToMenu()
    {
        howToPlayScreen.SetActive(false);
        menuOptions.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OnLoad()
    {
        SceneManager.LoadScene("Level1"); //charge le niveau 1 du jeu
    }
}
