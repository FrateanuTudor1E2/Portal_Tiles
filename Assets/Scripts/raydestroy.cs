using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raydestroy : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        //Destroy this gameobject
        Destroy(gameObject);
    }
}
