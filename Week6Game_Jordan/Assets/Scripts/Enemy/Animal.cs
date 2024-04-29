using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animal : MonoBehaviour
{
    GameManager gm;
    

    public int animal; //0 = bird
    
    

    Rigidbody rb;
    public float birdMoveSpeed;
    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = FindAnyObjectByType<GameManager>();
        

        // Destroy Bird
        if (animal == 0)
        {
            transform.position = BirdSpawnPos();
            //transform.localScale = new Vector3(1, Random.Range(.5f, 2), 1);
        }
    }

    // Update is called once per frame
    

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
        
    }

    

    Vector3 BirdSpawnPos()
    {
        // set bird spawn point 
        float ySpawnPoint = Random.Range(3, 10);
        return new Vector3(-14, ySpawnPoint, 72);
    }

    private void OnMouseDown()
    {
        if (gm.canShoot)
        {
            if (animal == 0)
            {
                rb.AddTorque(0, 0, Random.Range(-20, 20), ForceMode.Impulse);
                animal = -1;
                isDead = true;
                rb.useGravity = true;
                Destroy(gameObject, 5f);
                gm.score++;
            }
        }
    }
}
