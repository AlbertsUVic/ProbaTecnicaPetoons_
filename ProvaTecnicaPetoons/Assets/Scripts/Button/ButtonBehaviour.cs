using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{

    public GameObject Platform; //Referenciamos la plataforma que se mueve

    public bool player = false; //Booleano que nos indicar� si el jugador est� dentro del Trigger del bot�n


    public AudioSource emitter;
    public AudioClip buttonSound;

    private void Update()
    {
        if (player == true && Input.GetKeyDown(KeyCode.E))
        {
            emitter.PlayOneShot(buttonSound);
            Platform.GetComponent<Animator>().enabled = true;
        }

        //En el if comprovamos que el jugador est� dentro del trigger (con el player == true) y si es asi y tambien se ha pulsado la tecla E se inicia la animaci�n que hace que la plataforma se mueva.
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("Jugador");
            player = true;
        }

        //Si el jugador ha entrado dentro del Trigger Player se pone a true para indicar que puede pulsar el bot�n.
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player = false;
        }

        //Si el jugador ha salido del trigger Player se pone a false para indicar que no se puede pulsar el bot�n
    }
}
