using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCharacter : MonoBehaviour
{

    [SerializeField] float mouseSensitivity = 3.5f;
    public Transform cuerpoCharacter;

   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        cuerpoCharacter.Rotate(Vector3.up * mouseX);

    }
}
