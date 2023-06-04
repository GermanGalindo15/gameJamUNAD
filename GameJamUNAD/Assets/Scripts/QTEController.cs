using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class QuickTimeEventController : MonoBehaviour
{
    private bool touchDetected = false;
    private bool eventCompleted = false;
    private float waitTime;
    private float currentTime;

    [Range(3f, 8f)]
    public float minWaitTime = 2f; // Valor mínimo del tiempo de espera aleatorio
    [Range(3f, 8f)]
    public float maxWaitTime = 5f; // Valor máximo del tiempo de espera aleatorio

    public float delayBeforeSceneChange = 3f; // Tiempo de espera antes de cambiar a otra escena
    public TextMeshProUGUI messageText; // Objeto de texto para mostrar el mensaje
    public TextMeshProUGUI penaltyText; // Objeto de texto para mostrar la penalización

    void Start()
    {
        // Establecer tiempo de espera aleatorio entre minWaitTime y maxWaitTime
        waitTime = Random.Range(minWaitTime, maxWaitTime);
    }

    void Update()
    {
        if (!eventCompleted)
        {
            if (currentTime < waitTime)
            {
                currentTime += Time.deltaTime;
            }
            else if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    touchDetected = true;
                    eventCompleted = true;
                    ShowMessage("¡Toca la pantalla!");
                }
            }
        }
        else
        {
            // Esperar unos segundos antes de cambiar a otra escena
            delayBeforeSceneChange -= Time.deltaTime;
            if (delayBeforeSceneChange <= 0f)
            {
                // Cambiar a otra escena
                SceneManager.LoadScene("Juego");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (touchDetected)
        {
            float screenHalfWidth = Screen.width / 2f;

            if (collision.GetContact(0).point.x < screenHalfWidth)
            {
                Debug.Log("Tocó la mitad izquierda de la pantalla.");
                ShowPenalty("¡Penalización!");
                // Realiza las acciones correspondientes para la penalización del lado izquierdo.
            }
            else
            {
                Debug.Log("Tocó la mitad derecha de la pantalla.");
                ShowPenalty("¡Penalización!");
                // Realiza las acciones correspondientes para la penalización del lado derecho.
            }

            touchDetected = false;
            eventCompleted = true;
        }
    }

    void ShowMessage(string text)
    {
        if (messageText != null)
        {
            messageText.gameObject.SetActive(true);
            messageText.text = text;
        }
    }

    void ShowPenalty(string text)
    {
        if (penaltyText != null)
        {
            penaltyText.gameObject.SetActive(true);
            penaltyText.text = text;
        }
    }
}



