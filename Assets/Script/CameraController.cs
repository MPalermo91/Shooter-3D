using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
   public GameObject player;

    private Vector3 _offset;
    private Transform _transformCamera;
    private RaycastHit _hitCamera;
    
    void Start()
    {
       _offset = transform.position - player.transform.position;
       _offset = _transformCamera.localPosition;
    }

    
    void Update()
    {
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
        //   transform.LookAt(player.transform.position);


        if (Physics.Linecast(transform.position, _transformCamera.position + transform.localRotation * _offset, out _hitCamera))
        {
            _transformCamera.localPosition = new Vector3(0, 0, -Vector3.Distance(transform.position, _hitCamera.point));
        }
        else
        {
            _transformCamera.localPosition = Vector3.Lerp (_transformCamera.localPosition, _offset, Time.deltaTime);
        }
    }

   
    //    public float turnSpeed = 4.0f;
    //    public Transform player;

    //    private Vector3 offset;

    //    void Start()
    //    {
    //       offset = new Vector3(player.position.x, player.position.y + 8.0f, player.position.z + 7.0f);
    //    }

    //    void LateUpdate()
    //    {
    //        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
    //        transform.position = player.position + offset;
    //        transform.LookAt(player.position);
    //    }
}