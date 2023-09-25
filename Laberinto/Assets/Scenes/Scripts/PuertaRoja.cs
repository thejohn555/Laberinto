using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaRoja : MonoBehaviour
{
    bool sonido;
    bool triger;

    public GameObject jugador;
    public bool Llaveroja;

    // Start is called before the first frame update
    void Start()
    {
        sonido = false;

    }

    // Update is called once per frame
    void Update()
    {
        Llaveroja = jugador.GetComponent<controlador_final2>().Llaveroja;

        if (Input.GetKey(KeyCode.E) && sonido == false && triger == true)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            sonido = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "jugador" && Llaveroja == true)
        {
            triger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "jugador")
        {
            triger = false;
        }
    }
}