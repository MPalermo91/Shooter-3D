using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isPlayer = true;
    public float da�o = 20f;
    public float speedBullet = 5f;

    public GameObject instanciador;
    public GameObject da�oPlayer;
    public GameObject da�oEnemy;
    
    void Start()
    {
       // this.transform.position = new Vector3() * speedBullet;
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision bulletCollision)
    {
        if (isPlayer)
        {
            if (bulletCollision.transform.tag == "Enemies")
            {
                Instantiate(this.gameObject, this.transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (bulletCollision.transform.tag == "Player")
            {
                Instantiate(this.gameObject, this.transform.position, Quaternion.identity);
            }
        }
        Destroy(gameObject, 3.0f);
    }
}
