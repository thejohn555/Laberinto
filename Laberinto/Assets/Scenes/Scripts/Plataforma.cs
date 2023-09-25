using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    Vector3 Direccion;
    public GameObject padre;

    // Start is called before the first frame update
    void Start()
    {
        Direccion = Vector3.forward * 15;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Direccion * Time.deltaTime;

        if (transform.position.z>= -65)
        {
            Direccion *= -1;
        }
        if (transform.position.z <= -90)
        {
            Direccion *= -1;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag== "jugador")
        {
            collision.transform.parent = padre.transform;
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "jugador")
        {
            collision.transform.parent = null;
        }
    }
}
