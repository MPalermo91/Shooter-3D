using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.5f;

    private Vector3 _velocity = Vector3.zero;

    private Vector3 _offset;
    
    // Start is called before the first frame update
    void Start()
    {
        _offset = this.transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempPosition = target.position + _offset;

        this.transform.position = Vector3.SmoothDamp(this.transform.position, tempPosition,ref _velocity, smoothTime );
    }
}
