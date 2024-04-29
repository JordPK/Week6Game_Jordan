using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public int birdSpawnRate;

    public int score;

    public AudioSource aud1;
    public AudioClip gunShot;
    public AudioClip reloadSFX;
    public AudioClip OutOfAmmoSFX;

    public bool canShoot = true;
    public bool isReloading = false;
    public int maxBullets;
    public int BulletCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBird());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            aud1.PlayOneShot(reloadSFX, .75f);
            StartCoroutine(ReloadGun());
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
    }

    IEnumerator ReloadGun()
    {
        BulletCount = 0;
        yield return new WaitForSeconds(1);
        BulletCount = maxBullets;
    }

    IEnumerator SpawnBird()
    {
        while (true)
        {
            yield return new WaitForSeconds(birdSpawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
