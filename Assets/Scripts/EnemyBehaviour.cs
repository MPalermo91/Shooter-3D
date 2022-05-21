using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float health = 100f;
    public float coldDown = 3f;

    public GameObject enemyBullet;

    float bulletSpeed;

    float timeCount = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0f) 
        {
            Destroy(gameObject);
        }
        
    }

    public void Damage(float hurt)
    {
        health -= hurt;

        Debug.Log("health: " + health);
    }

    void OnTriggerStay(Collider col)
    {
        if(col.transform.name == "Player")
        {
            transform.LookAt(col.transform.position);

            timeCount += Time.deltaTime;

            if(timeCount >= coldDown)
            {
                 shoot();
                 timeCount = 0f;
            }

           
        }
    }

    private void shoot()
    {
        //shooting to player
        Debug.Log("Shoot");
    }
}
