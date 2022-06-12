using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public float vidaEnemy = 150f;
    public float speedBulletEnemy = 10f;

    private float _couldDown = 0f;

    public GameObject player;
    public GameObject enemyBullet;
    public GameObject instanciadorBullet;

    void Start()
    {
      enemyBullet.transform.position = player.transform.position * speedBulletEnemy * Time.deltaTime;  
    }

    void Update()
    {
        transform.LookAt(player.transform.position);
        _couldDown += Time.deltaTime;
        if (_couldDown >= 2.5f)
        {
            Shoot();
            _couldDown = 0f;
            Debug.Log("Shoot");
            //    Debug.Log("Disparo");     //Lo comente porque funciona
        }
        
       

        if (vidaEnemy <= 0f)
        {
            Destroy(gameObject); //cuando la vida llega a cero destruye al enemigo
        }
    }


    private void OnCollisionEnter(Collision col)
    {
        vidaEnemy -= 0f;
      //  Debug.Log("Resto Vida Enemy");   //Lo comente porque funciona
    }

    private void Shoot()
    {
        
        GameObject tempBullet = Instantiate(enemyBullet, instanciadorBullet.transform.position, instanciadorBullet.transform.rotation) as GameObject;
        //tempBullet.SetBulletPlayer(false);

        Rigidbody rgBullet = tempBullet.GetComponent<Rigidbody>();
        rgBullet.AddForce(enemyBullet.transform.forward * speedBulletEnemy * Time.deltaTime);

        Destroy(tempBullet, 2.0f);
    }

}
