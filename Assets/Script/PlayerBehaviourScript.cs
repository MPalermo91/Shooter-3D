using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    public float speedPlayer = 0.5f;
    public float speedPlus = 4f;
    public int vida = 100;

    private Vector3 _rot;
    private Vector3 _move;
    private float _gravity = -36.8f;

    public GameObject marcadorCamino;

    void Start()
    {
        
    }

    public void Awake()
    {
        
    }
    void Update()
    {
        Move();
        CamRotate();
        Correr();
        Marcador();
    }

    private void Move()
    {
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");


        Vector3 move = transform.forward * hMove + transform.right * vMove;

        
    }

    private void CamRotate()
    {
        _rot.x = Input.GetAxis("Mouse X");
        _rot.y = Input.GetAxis("Mouse Y");

        transform.rotation *= Quaternion.Euler(0, _rot.x, 0);
    }
    private void Correr()
    {
        if (Input.GetKey(KeyCode.LeftShift) == true)   //Si presionamos Shift Izquierdo Corre
        {
            transform.Translate(Vector3.Normalize(_move) * speedPlus * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftShift) == false) // Si dejamos de presionar Shift Izquierdo Camina
        {
            transform.Translate(Vector3.Normalize(_move) * speedPlayer * Time.deltaTime);
        }
    }
    private void Marcador ()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(marcadorCamino, this.transform.position, Quaternion.identity);
        }

    }



}
