using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    private Vector3 _move;

    public GameObject bulletSpawner;

    public GameObject bullet;

    public float bulletSpeed = 10f;

    private RaycastHit hit;

    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        var moveHorizontal =  Input.GetAxis("Horizontal");
        var moveAdvance = Input.GetAxis("Vertical") * -1;

        _move = new Vector3(moveAdvance, 0.0f, moveHorizontal);

        transform.Translate(Vector3.Normalize(_move) * speed * Time.deltaTime);
   
        if(Input.GetButtonDown("Fire1"))
        {
            //Do something
            Shoot();
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out hit, layerMask))
        {
            //obtengo la dirección entre el player y el mouse
            Vector3 hitDir =  hit.point - transform.position;
            
            //calculo el angulo que tengo que girar el player para que queda apuntando al mouse
            float angleDir = (Mathf.Atan2(hitDir.x, hitDir.z) * Mathf.Rad2Deg)+90f;
           
           //giro el player en la direccion y angulo calculado
            transform.rotation = Quaternion.AngleAxis(angleDir,Vector3.up);
           
            
            //Dibuja una linea roja desde el player al pùnto
           Debug.DrawLine(transform.position, hit.point, Color.red);
            //Dibuja una linea desde el centro de la camra al punto donde esta el mouse con un largo de 100 unidads
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.white);
        }
    }

    void Shoot()
    {
        GameObject tempBullet = Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation) as GameObject;

        Rigidbody rg = tempBullet.GetComponent<Rigidbody>();

        rg.AddForce(bulletSpawner.transform.right * bulletSpeed);

        Destroy(tempBullet, 3.0f);
    }
}
