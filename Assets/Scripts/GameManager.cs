using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen; //référence au gameover screen
    [SerializeField] private GameObject winScreen; //référence à l'ecran de fin de niveau
    [SerializeField] private GameObject miniMap; //référence à la minimap
    [SerializeField] private GameObject loadScreen; //référence à l'écran de chargement
    private float loadTime = 5;
    private bool isLoading = false;
    private bool isReplayingLevel = false;
    private bool isNextLevel = false;

    [SerializeField] AudioSource audioS; //musique du jeu
    [SerializeField] AudioSource[] audioSFX; //SFX du jeu

    public static bool isPaused = false; //est-ce que je suis en pause
    [SerializeField] private GameObject pauseMenu; //référence au menu pause

    int currentLevel;


    private void Awake()
    {
        pauseMenu.SetActive(false);
        loadScreen.SetActive(false);
        gameOverScreen.SetActive(false);


        currentLevel = SceneManager.GetActiveScene().buildIndex; //reférence à la scène active
    }

    public void ReturnToMenu()
    {
        isLoading = true;
        loadScreen.SetActive(true);
        winScreen.SetActive(false);

        Time.timeScale = 1f; 
        
        audioS.Stop();
        if(isPaused)
        {
            pauseMenu.SetActive(false);
        }
    }

    public void OnLoad()
    {
        loadScreen.SetActive(false);
        SceneManager.LoadScene("StartMenu"); //charge la scène d'entrée du jeu
    }

    public void ReplayLevel()
    {
        isReplayingLevel = true;
        winScreen.SetActive(false);
        loadScreen.SetActive(true);

            float timer = Time.deltaTime;
            loadTime -= timer; //countdown
            Debug.Log(loadTime);
            if (loadTime <= 0)
            {
                SceneManager.LoadScene(currentLevel); //charge le niveau actuel
            }      
    }

    public void NextLevel()
    {
        isNextLevel = true;
        isLoading = true;
        winScreen.SetActive(false);
        loadScreen.SetActive(true);
        if (isLoading)
        {
            float timer = Time.deltaTime;
            loadTime -= timer; //countdown
            Debug.Log(loadTime);
            if (loadTime <= 0)
            {
                    SceneManager.LoadScene(sceneBuildIndex: currentLevel +1); //charge le niveau suivant
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        foreach (AudioSource audioSource in audioSFX)
        {
            audioSource.Play();
        }
        Time.timeScale = 1f; //remet le temps de jeu à son cours normal
        isPaused = false;

    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        foreach(AudioSource audioSource in audioSFX)
        {
            audioSource.Pause();
        }

        Time.timeScale = 0f; //freeze le temps dans le jeu
        isPaused = true;

    }

    private void Start()
    {
        ////Cacher le curseur
        //Cursor.lockState = CursorLockMode.Locked; //gèle le curseur au centre de l'ecran
        //Cursor.visible = false; //cache le curseur
    }

    // Update is called once per frame
    void Update()
    {
        if (isLoading)
        {
            float timer = Time.deltaTime;
            loadTime -= timer; //countDown
            Debug.Log(loadTime);
            if (loadTime <= 0)
            {
                OnLoad();
            }
        }

        if (isReplayingLevel)
        {
            loadScreen.SetActive(true);
            float timer = Time.deltaTime;
            loadTime -= timer; //countDown
            Debug.Log(loadTime);
            if (loadTime <= 0)
            {
                SceneManager.LoadScene(currentLevel); //recharge le niveau actuel
            }
        }


        if (isNextLevel)
        {
            float timer = Time.deltaTime;
            loadTime -= timer; //countDown
            Debug.Log(loadTime);
            if (loadTime <= 0)
            {
                    SceneManager.LoadScene(sceneBuildIndex: currentLevel + 1); //charge le niveau suivant
            }
        }


        if (Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused)
            {
                ResumeGame(); //résume le jeu
            }
            else
            {
                PauseGame(); //mets le jeu en pause
            }
        }

        ////Gestion du curseur
        //if(isPaused)
        //{
            
        //}
        //else
        //{
        //    //Cacher le curseur
        //    Cursor.lockState = CursorLockMode.Locked; //geler le curseur au centre de l'ecran
        //    Cursor.visible = false; //cacher le curseur
        //}
    }
}
