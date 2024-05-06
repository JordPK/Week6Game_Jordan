using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    uiManager ui;
    [Header("Animal Spawning")]
    public List<GameObject> targets;
    public List<GameObject> Deer;
    public float birdSpawnRate;
    public float deerSpawnRate;

    public bool isGameStart;

    [Header("GameMode & UI")]
    public uiManager uiManager;
    public int score;
    public float timeLeft = 60f;
    public bool isGameOver = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI timeLeftText;
    public TextMeshProUGUI ammoText;   

    [Header("Audio")]
    public AudioSource aud1;
    public AudioClip gunShot;
    public AudioClip reloadSFX;
    public AudioClip OutOfAmmoSFX;

    [Header("Player Gun")]
    public bool canShoot = true;
    public bool isReloading = false;
    public int maxBullets;
    public int BulletCount;

    // Start is called before the first frame update
    void Start()
    {
        if (isGameStart)
        {
            StartCoroutine(SpawnBird());
            StartCoroutine(SpawnDeer());
        }
        
        ui = FindObjectOfType<uiManager>();
        
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(Time.timeScale);
        if (ui.isPaused == false && isGameStart)
        {

            Time.timeScale = 1.0f;

            if (Input.GetKeyDown(KeyCode.R) && BulletCount < maxBullets)
            {
                aud1.PlayOneShot(reloadSFX, .5f);
                StartCoroutine(ReloadGun());
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                ui.PauseGame();
            }

            if (BulletCount > 0)
            {
                canShoot = true;
            }
            else
            {
                canShoot = false;
            }

            if (Input.GetMouseButtonDown(0) && canShoot)
            {
                aud1.PlayOneShot(gunShot, 1);
                BulletCount--;
            }

            if (Input.GetMouseButtonDown(0) && !canShoot)
            {
                aud1.PlayOneShot(OutOfAmmoSFX);
                canShoot = false;
            }

            // UI & GameMode

            timeLeft -= Time.deltaTime;

            //Score Text
            scoreText.text = "Score :" + score;

            //Final Score
            finalScoreText.text = "Score :" + score;

            // Time Left Text
            timeLeftText.text = "Time Left :" + Mathf.RoundToInt(timeLeft).ToString();

            // Ammo Text

            ammoText.text = "Ammo:" + BulletCount.ToString();

            if (score % 5 == 0 && score != 0)
            {
                
            }

            if (timeLeft <= 0)
            {
                ui.GameOverScreen();
            }
        }
        birdSpawnRate = PlayerPrefs.GetFloat("birdDifficulty");
        deerSpawnRate = PlayerPrefs.GetFloat("deerDifficulty");
    }

    IEnumerator ReloadGun()
    {
        BulletCount = 0;
        yield return new WaitForSeconds(1);
        BulletCount = maxBullets;
    }

    public IEnumerator SpawnBird()
    {
        while (true)
        {
            yield return new WaitForSeconds(birdSpawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public IEnumerator SpawnDeer()
    {
        while (true)
        {
            yield return new WaitForSeconds(deerSpawnRate);
            int index = Random.Range(0, Deer.Count);
            Instantiate(Deer[index]);
        }
    }
}
