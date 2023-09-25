using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlador_final2 : MonoBehaviour
{
    public float velocidad;
    public float velocidadgiro;
    public float salto;
    public GameObject Paredroja;
    public GameObject Paredazul;
    public GameObject Paredverde;

    Vector3 Inicio;
    bool activadorojo;
    bool activadorverde;
    bool activadorazul;
    public bool Llaveroja;
    public bool Llaveverde;
    public bool LlaveAzul;
    float saltos;
    float saltosMax;
    float colecionable;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        saltos = 0;
        saltosMax = 1;
        Llaveroja = false;
        Llaveverde = false;
        LlaveAzul = false;
        Inicio = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity.y < -0.1f)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(-transform.up * (salto / 12), ForceMode.Impulse);

            if (Physics.Raycast(transform.position, -transform.up, out hit, 2f))
            {
                saltos = 0;
            }
        }

        

        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*velocidad * Input.GetAxis("Vertical"),ForceMode.Impulse);

        transform.Rotate(Vector3.up,Input.GetAxis("Horizontal") * velocidadgiro * Time.deltaTime);



        if (Input.GetKeyDown(KeyCode.Space) && saltos < saltosMax)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(transform.up * salto, ForceMode.Impulse);

            saltos += 1;
        }


        if (Input.GetKey(KeyCode.E) && activadorojo == true)
        {
            Destroy(Paredroja.gameObject);
        }
        if (Input.GetKey(KeyCode.E) && activadorazul == true)
        {
            Destroy(Paredazul.gameObject);
        }
        if (Input.GetKey(KeyCode.E) && activadorverde ==true)
        {
            Destroy(Paredverde.gameObject);
        }


    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Llave Roja")
        {
            Llaveroja = true;

            Destroy(collision.gameObject, 2);
        }
        if (collision.gameObject.tag == "Llave azul")
        {
            LlaveAzul = true;

            Destroy(collision.gameObject, 2);
        }
        if (collision.gameObject.tag == "Llave verde")
        {
            Llaveverde = true;

            Destroy(collision.gameObject, 2);
        }
        
    }
     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Activador Rojo" && Llaveroja == true)
        {
            activadorojo = true;
        }
        if (other.gameObject.tag == "Activador azul" && LlaveAzul == true)
        {
            activadorazul = true;
        }
        if (other.gameObject.tag == "Activador verde" && Llaveverde == true)
        {
            activadorverde = true;
        }
        if (other.gameObject.tag == "kill")
        {
            transform.position = Inicio;
        }
        if (other.gameObject.tag == "coleccionable")
        {
            colecionable++;
            
            if (other.gameObject.name == "velocidad")
            {
                velocidad += 0.5f;
            }
            if (other.gameObject.name == "salto")
            {
                saltosMax += 1;
            }

            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "checkpoint")
        {
            Inicio = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Activador Rojo")
        {
            activadorojo = false;
        }
        if (other.gameObject.tag == "Activador azul")
        {
            activadorazul = false;
        }
        if (other.gameObject.tag == "Activador verde")
        {
            activadorverde = false;
        }
    }

}
