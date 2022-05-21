using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{   
    public float damage = 20f;

    public GameObject debris;
   
    void OnCollisionEnter(Collision col)
    {
        //Debug.Log(col.transform.name);

        if(col.transform.tag == "Enemies")
        {
            Instantiate(debris, this.transform.position, Quaternion.identity);   
           
        }
       
        Destroy(gameObject);


    }


}
