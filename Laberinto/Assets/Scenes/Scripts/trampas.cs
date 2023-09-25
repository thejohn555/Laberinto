using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampas : MonoBehaviour
{
    Vector3 Direccion;
    // Start is called before the first frame update
    void Start()
    {
        Direccion = Vector3.forward * 15;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Direccion * Time.deltaTime;

        if (transform.position.z >= -90)
        {
            Direccion *= -1;
        }
        if (transform.position.z <= -120)
        {
            Direccion *= -1;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "jugador")
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }
}
