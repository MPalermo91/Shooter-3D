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

    public GameObject marcadorCamino;

    void Start()
    {
        
    }

   
    void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveAdvance = Input.GetAxis("Vertical");
        
        _move = new Vector3(moveHorizontal, 0.0f, moveAdvance);
        
       // transform.Translate(Vector3.Normalize(_move) * speedPlayer * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftShift) == true)   //Si presionamos "LeftShift" Corre
        {
            transform.Translate(Vector3.Normalize(_move) * speedPlus * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftShift) == false) // Si dejamos de presionar "LeftShift" Camina
        {
            transform.Translate(Vector3.Normalize(_move) * speedPlayer * Time.deltaTime);
        }

       

        _rot.x = Input.GetAxis("Mouse X");
        _rot.y = Input.GetAxis("Mouse Y");

       transform.rotation *= Quaternion.Euler(0, _rot.x, 0);

        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(marcadorCamino, this.transform.position, Quaternion.identity);
            Debug.Log("Se crea un marcador de camino");
        }
    }




}
