using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviourScript : MonoBehaviour
{
    public float speedPlayer = 1.5f;
    public float speedPlus = 2.5f;

    private Vector3 _rot;
    private Vector3 _move;
    


    void Start()
    {
        
    }

   
    void Update()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveAdvance = Input.GetAxis("Vertical");
        
        _move = new Vector3(moveHorizontal, 0.0f, moveAdvance);

        if (Input.GetKeyDown(KeyCode.LeftShift) == true)
        {
            transform.Translate(Vector3.Normalize(_move) * speedPlus * Time.deltaTime);
            Debug.Log("Corriendo");
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift) == false)
        {
            transform.Translate(Vector3.Normalize(_move) * speedPlayer * Time.deltaTime);
            Debug.Log("Caminando");
        }
        
        _rot.x = Input.GetAxis("Mouse X");
        _rot.y = Input.GetAxis("Mouse Y");

       transform.rotation *= Quaternion.Euler(0, _rot.x, 0);
    }




}
