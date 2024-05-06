using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Animal : MonoBehaviour
{
    GameManager gm;
    Rigidbody rb;

    public int animal; //0 = bird // 1= Fish

    public float birdMoveSpeed;
    public float deerMoveSpeed;

    public GameObject bloodSplat;

    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = FindAnyObjectByType<GameManager>();

        
        if (animal == 0)
        {
            transform.position = BirdSpawnPos();
        }

        if (animal == 1)
        {
            transform.position = BirdSpawnPos();
        }

        if (animal == 3)
        {
            transform.position = DeerSpawnPos();
        }
    }
    void FixedUpdate()
    {
        // set bird move speed
        if (animal == 0)
        {
            if (isDead == false)
            {
                rb.velocity = new Vector3(birdMoveSpeed, 0, 0);
            }
        }
        if (animal == 1)
        {
            if (isDead == false)
            {
                rb.velocity = new Vector3(birdMoveSpeed, 0, 0);
            }
        }
            if (animal == 3)
        {
            if (isDead == false) 
            {
                rb.velocity = new Vector3(deerMoveSpeed, 0, 0);
            }
        }
    }
    Vector3 BirdSpawnPos()
    {
        // set bird spawn point 
        float ySpawnPoint = Random.Range(3, 10);
        return new Vector3(-14, ySpawnPoint, 72);
    }

    Vector3 DeerSpawnPos()
    {
        float zSpawnPoint = Random.Range(32, 10);
        return new Vector3(-12, .5f, 32);
    }

    private void OnMouseDown()
    {
        if (gm.canShoot && !gm.isGameOver)
        {

            if (animal == 0)
            {
                Destroy(Instantiate(bloodSplat,transform.position, bloodSplat.transform.rotation),2);
                rb.AddTorque(0, 0, Random.Range(-20, 20), ForceMode.Impulse);
                animal = -1;
                isDead = true;
                rb.useGravity = true;
                Destroy(gameObject, 5f);
                gm.score++;
            }

            if (animal == 1)
            {
                Destroy(Instantiate(bloodSplat, transform.position, bloodSplat.transform.rotation), 2);
                rb.AddTorque(0, 0, Random.Range(-20, 20), ForceMode.Impulse);
                animal = -1;
                isDead = true;
                rb.useGravity = true;
                Destroy(gameObject, 5f);
                gm.score += 5;
            }
            if (animal == 3)
            {
                animal = -1;
                isDead = true;
                rb.AddTorque(0, 0, Random.Range(-20, 20), ForceMode.Impulse);
                rb.useGravity = true;
                Destroy(gameObject, 2f);
                gm.score += 2;
            }
        }
    }
}
