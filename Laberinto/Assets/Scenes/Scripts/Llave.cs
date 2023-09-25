using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "jugador")
        {
            MeshRenderer Visble = GetComponent<MeshRenderer>();
            Visble.enabled = false;
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }
}
