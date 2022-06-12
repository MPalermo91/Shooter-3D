using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    public CharacterController controlMov; //Llamamos al Character controles para tomar sus funciones de movimientos y asignarmos al personaje

    public float speed = 5f;               //Velocidad en estado "normal" del personaje (Caminar)
    public float speedPlus = 4f;           //La valocidad a la que se mueve el personaje Presionando Shift (Correr)
    public LayerMask isLayer = -1;         //Se coloca siempre un valor para no dejarlo en blanco. Pero luego se lo modifica en el inspector por el/los Layer/s que necesitemos.

    public int vida = 100;                 //Vida maxima inicial del personaje.

    public GameObject marcadorCamino;      //Llamamos al Objeto (prefabs) que nos permite generar las luces marcadoras de camino.

    private Vector3 movCharacter;          //Variable en la cual asignamos el movimiento en "X" y en "Z" del personaje. En "Y" validamos si colisiona con el piso.
    private float _gravity = -16.8f;       //Nos indica si esta colisionando o no con el Piso (true or False).
    //private int _isLayer = 1 << 3;       //Es la gravedad de caida cuando el personaje no esta colisionando contra el piso. Es lo que permite bajar escaleras y objetos sin quedar volando
    private bool _isFloor;                 //Esta es la otra forma de Identificar en que Layer vamos a "Checkear" la colision con Physic.CheckSphere.

    void Start()
    {

    }


    void Update()
    {

        Move();
        Correr();
        Marcador();

        
    }
    private void Move()   //Toda la funcion del movimiento y gravedad del personaje
    {
        float movimientoX = Input.GetAxis("Horizontal"); //Movimiento Horizontal del Personaje (W y S)
        float movimientoZ = Input.GetAxis("Vertical");    // Movimiento Vertical del Personaje (A y D)

        movCharacter = transform.right * movimientoX + transform.forward * movimientoZ;

        movCharacter.y = _gravity * Time.deltaTime;

        _isFloor = Physics.CheckSphere(transform.position, 0.1f, isLayer, QueryTriggerInteraction.Ignore);

        if (_isFloor && movCharacter.y < 0f)
        {
            movCharacter.y = 0f;
        }

        controlMov.Move(movCharacter * speed * Time.deltaTime);
    }

    private void Correr() //Funcion que permite Correr o caminar
    {
        if (Input.GetKey(KeyCode.LeftShift) == true)   //Si presionamos "LeftShift" Corre
        {
            controlMov.Move(movCharacter * speedPlus * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftShift) == false) // Si dejamos de presionar "LeftShift" Camina
        {
            controlMov.Move(movCharacter * speed * Time.deltaTime);
        }
    }

    private void Marcador() //Funcion para instanciar al marcador de camino
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(marcadorCamino, this.transform.position, Quaternion.identity);
        }
    }
}

