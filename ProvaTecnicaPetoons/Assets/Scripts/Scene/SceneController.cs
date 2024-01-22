using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneController : MonoBehaviour
{
    public GameObject[] TotalCoins; //Array donde guardaremos todas las monedas de la escena
    CharacterBehaviour character; //Para hacer referencia al script del jugador y poder acceder a sus variables publicas
    public TMP_Text CoinsText; //Texto que nos mostrará la cantidad de monedas recogidas por el jugador

    public TMP_Text WinText; //Texto que nos avisárá cuando hayamos recogido todas las monedas
    public TMP_Text GeneralText; //Texto que nos avisárá cuando hayamos recogido todas las monedas

    public AudioSource emitter; 
    public AudioClip successSound;

    ButtonBehaviour button;

    // Start is called before the first frame update
    void Start()
    {

        TotalCoins = GameObject.FindGameObjectsWithTag("Coin"); //Aqui añadimos al array anterior todos los GameObjects con tag Coin

        character = FindObjectOfType<CharacterBehaviour>(); //Buscamos el script de CharacterBehaviour para acceder a las variables publicas

        button = FindObjectOfType<ButtonBehaviour>();

    }

    // Update is called once per frame
    void Update()
    {
        
        CoinsText.text = "Coins:" + character.coins; //Actualizamos el texto segun las monedas que tenga el jugador

        /*for (int i = 0; i < TotalCoins.Length; i++)
        {
            if (character.coins == TotalCoins.Length)
            {
                WinText.text = "YOU WIN!";
                emitter.PlayOneShot(successSound);
            }
        }*/

        if (character.coins == TotalCoins.Length)
        {
            WinText.text = "YOU WIN!";
            emitter.PlayOneShot(successSound);
        }
        //Este for es para saber cuantas monedas hay en total y cuando el jugador haya recogido el mismo numero de monedas como hay en la escena se mostrará el mensaje de vicotria y se reproducirá el sonido.



        if (button.player == true)
        {
            GeneralText.text = "Press 'E'";
        }
        else
        {
            GeneralText.text = "";
        }
    
    }
}
