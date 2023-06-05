using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QTEController : MonoBehaviour
{
    public RawImage rightImage;
    public RawImage leftImage;
    public Button leftButton;
    public Button rightButton;

    public float tiempoDeEspera = 5f;

    [Range (2f, 8f)]
    public float minInterval = 2f;

    [Range (2f, 8f)]
    public float maxInterval = 5f;

    private bool canTap = false;
    private bool eventStarted = false;

    private float nextInterval;

    private void Start()
    {
        nextInterval = GetRandomInterval();
        Invoke("AllowTap", nextInterval);
    }

    private void Update()
    {
        if (canTap)
        {
            leftButton.onClick.AddListener(OnLeftButtonClick);
            rightButton.onClick.AddListener(OnRightButtonClick);
        }
    }

    private void OnLeftButtonClick()
    {
        if (!eventStarted)
        {
            StartEvent(true);
        }
        else
        {
            EndEvent(true);
        }
    }

    private void OnRightButtonClick()
    {
        if (!eventStarted)
        {
            StartEvent(false);
        }
        else
        {
            EndEvent(false);
        }
    }

    private void StartEvent(bool isLeft)
    {
        if (isLeft)
        {
            leftImage.gameObject.SetActive(true);
            // Aquí puedes asignar la imagen correspondiente al lado izquierdo usando penaltyImage.sprite = spriteLadoIzquierdo;
        }
        else
        {
            rightImage.gameObject.SetActive(true);
            // Aquí puedes asignar la imagen correspondiente al lado derecho usando startImage.sprite = spriteLadoDerecho;
        }

        eventStarted = true;
    }

    private void EndEvent(bool isLeft)
    {
        if (isLeft)
        {
            // El jugador tocó el lado izquierdo antes de tiempo
            Debug.Log("Penalización - Lado izquierdo");
        }
        else
        {
            // El jugador tocó el lado derecho antes de tiempo
            Debug.Log("Penalización - Lado derecho");
        }

        // Restablecer los valores
        leftImage.gameObject.SetActive(false);
        rightImage.gameObject.SetActive(false);
        canTap = false;
        eventStarted = false;

        nextInterval = GetRandomInterval();
        Invoke("AllowTap", nextInterval);

        StartCoroutine(ChangeSceneAfterDelay(tiempoDeEspera));

        // Aquí puedes cambiar a otra escena después de un tiempo usando StartCoroutine(ChangeSceneAfterDelay(tiempoDeEspera));
    }

    private void AllowTap()
    {
        canTap = true;
    }

    private float GetRandomInterval()
    {
        return Random.Range(minInterval, maxInterval);
    }

    // Coroutine para cambiar a otra escena después de un tiempo
    private IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene("Juego");
    }
}




