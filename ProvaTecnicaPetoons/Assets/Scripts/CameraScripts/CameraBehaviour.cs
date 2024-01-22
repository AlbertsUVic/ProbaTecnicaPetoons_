using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    private Vector2 angle = new Vector2(-90 * Mathf.Deg2Rad, 0); //Este angulo es para que la camara empieze mirando al personaje desde atras y lo convertimos a radiantes

    public Transform follow; //Cogemos el empty object asociado al jugador para mas tarde hacer que la camara lo tome como objetivo
    public float distance; // Esta será la distància a la que se encuentre la camara del jugador
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float hor = Input.GetAxis("Mouse X"); //Cogemos el input del mouse cunado se mueve en el eje horizontal

        if (hor != 0)
        {
            angle.x += hor * Mathf.Deg2Rad * 2; //Si es diferente de zero entonces el angulo creado anteriormente le sumamos el valor del input horizontal y convertimos los grados a radiantes
        }

        float ver = Input.GetAxis("Mouse Y"); //Cogemos el input Vertical del mouse

        if (ver != 0)
        {
            angle.y += ver * Mathf.Deg2Rad;//Hacemos lo mismo que con el horizontal pero marcando limites para que no de la vuelta entera al personaje
            angle.y = Mathf.Clamp(angle.y, -60 * Mathf.Deg2Rad, 2 * Mathf.Deg2Rad); 
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 orbit = new Vector3(Mathf.Cos(angle.x) * Mathf.Cos(angle.y), -Mathf.Sin(angle.y), -Mathf.Sin(angle.x) * Mathf.Cos(angle.y)); //Creamos una variable llamada orbit que con el seno y el coseno nos permitirá orbitar sobre el mismo jugador
        transform.position = follow.position + orbit * distance; //Aqui hacemos que rote en torno al jugador 
        transform.rotation = Quaternion.LookRotation(follow.position - transform.position); //Aqui le decimos que a parte de rotar en torno al jugador, rote mirandolo 
    }
}
