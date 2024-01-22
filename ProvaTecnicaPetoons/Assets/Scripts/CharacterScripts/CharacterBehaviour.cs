using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{

    float speed = 8f; //Velocidad del jugador
    float horizontalInput; //Input para el eje horizontal "A y D"
    float verticalInput; //Input para el eje horizontal "W y S"

    public float rotationSpeed = 410f; //Rotación del jugador para girar quando gire el eje X (y la camara)

    Rigidbody rb;

    public float jumpForce = 7.5f; //Fuerza aplicada al salto
    bool canJump = false; //Booleano para comprovar que puede saltar
    bool isJumping = false; //Booleano para saber si está saltando

    

    public int coins = 0; //Contador de monedas recogidas


    public AudioSource emitter;
    public AudioClip coinSound;
    public AudioClip jumpSound;



    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //Cogemos el RigidBody del jugador para aplicarle fisicas de salto

        transform.Rotate(new Vector3(0, 0, 0));

    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal"); //Cogemos el eje horizontal
        float verticalInput = Input.GetAxis("Vertical"); //Cogemos el eje vertical


        transform.Translate(new Vector3(horizontalInput, 0.0f, verticalInput) * Time.deltaTime * speed); //Movimiento del Jugador, con un Vector en el que le pasamos el eje horizontal y el eje vertical, lo multiplicams por deltaTime para ... y lo multiplicamos por la velcidad a la que queremos que se mueva

        float rotationY = Input.GetAxis("Mouse X"); //Cogemos la rotacion en el eje horizontal (X) del ratón

        transform.Rotate(new Vector3(0, rotationY * Time.deltaTime * rotationSpeed, 0)); //Aplicamos una rotación al jugador con la rotación anterior para que gire al mover el Mouse, así como la camara (en su debido script)



        Vector3 floor = transform.TransformDirection(Vector3.down); //Cogemos la dirección de abajo del jugador, le llamo floor porque esta mirando al suelo

        if (Physics.Raycast(transform.position, floor, 0.63f)) //Comprovamos con unraycast y la direccion anterior que el jugador esta tocando el suelo y por lo tanto puede saltar
        {
            canJump = true;
        }
        else //Si ya esta saltando o bien esta cayendo de alguna plataforma, es decir que no está tocando el suelo, no puede saltar
        {
            canJump = false;
        }
        
        isJumping = Input.GetButtonDown("Jump"); //Cogemos por defecto el "Boton" de unity para saltar y con el if comprovamos si puede saltar y si es asi al pulsar el boton añadimos una fuerza para que salte

        if (isJumping && canJump)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);

            emitter.PlayOneShot(jumpSound);
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            coins++;
            emitter.PlayOneShot(coinSound);
            Destroy(other.gameObject);
        }
    }



}
