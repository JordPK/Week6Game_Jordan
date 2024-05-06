using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class uiManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider sfxSlider;
    public Canvas gameUI;
    public Canvas pauseMenu;
    public Canvas gameOverUI;
    public Canvas mainMenu;
    public Canvas difficultyMenu;
    public AudioSource BGM;
    public AudioSource UIAudio;
    public AudioSource sfxAudio;

    public AudioClip clickSFX;

    //public float difficulty;

    GameManager gm;
    Volume blurVolume;

    //public AudioMixer Mixer;

    public bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();

        float bgmVolume = PlayerPrefs.GetFloat("volumeSlider");
        volumeSlider.value = bgmVolume;

        float sfxVolume = PlayerPrefs.GetFloat("sfxSlider");
        sfxSlider.value = sfxVolume;


        
    }   

    // Update is called once per frame
    void Update()
    {
        BGM.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("volumeSlider", volumeSlider.value);

        sfxAudio.volume = sfxSlider.value;
        PlayerPrefs.SetFloat("sfxSlider", sfxSlider.value);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        
    }
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0;
        Cursor.visible = true;
        gameUI.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(true);
    }
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        gameUI.gameObject.SetActive(true);
        pauseMenu.gameObject.SetActive(false);
    }

    public void DifficultyMenu()
    {
       mainMenu.gameObject.SetActive(false);
       difficultyMenu.gameObject.SetActive(true);
       volumeSlider.gameObject.SetActive(false);
       sfxSlider.gameObject.SetActive(false);
    }

    public void BackToMainMenu()
    {
        difficultyMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
        volumeSlider.gameObject.SetActive(true);
        sfxSlider.gameObject.SetActive(true);
    }
    public void GameOverScreen()
    {
        isPaused = true;
        Time.timeScale = 0;
        Cursor.visible = true;
        gameOverUI.gameObject.SetActive(true);
        gameUI.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit!");
    }
    public void SetBirdDifficulty(float difficulty)
    {
        //gm.birdSpawnRate = difficulty;
        PlayerPrefs.SetFloat("birdDifficulty", difficulty);
    }

    public void SetDeerDifficulty(float difficulty)
    {
        //gm.deerSpawnRate = difficulty;
        PlayerPrefs.SetFloat("deerDifficulty", difficulty);
    }

    public void PlayClickSFX()
    {
        UIAudio.PlayOneShot(clickSFX);
    }
}
