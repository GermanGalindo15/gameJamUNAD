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
    public RawImage warImage;
    public RawImage leftHand;
    public RawImage rightHand;
   
    

    private bool leftButtonPressed = false;
    private bool rightButtonPressed = false;

    public float delay = 5f;

    [Range (2f, 8f)]
    public float minInterval = 2f;

    [Range (2f, 8f)]
    public float maxInterval = 5f;

    private bool canTap = false;
    private bool eventStarted = false;

    private float nextInterval;

    private void Start()
    {
        leftButtonPressed = false;
        rightButtonPressed = false;

        nextInterval = GetRandomInterval();
        Invoke("AllowTap", nextInterval);

        leftButton.onClick.AddListener(OnLeftButtonClick);
        rightButton.onClick.AddListener(OnRightButtonClick);

        rightImage.gameObject.SetActive(false);
        leftImage.gameObject.SetActive(false);
        warImage.gameObject.SetActive(false);

        
    }

    private void Update()
    {
        if (canTap)
        {
            

            warImage.gameObject.SetActive(true);
    
        }
        
        if(leftButtonPressed == true)
        {
            warImage.gameObject.SetActive(false);
            Invoke("ChangeScene", delay);
        }
        else if(rightButtonPressed == true)
        {
            warImage.gameObject.SetActive(false);
            Invoke("ChangeScene", delay);
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
        if (!leftButtonPressed)
        {
            EndEvent(true);
        }
    }

    leftButton.interactable = false;
    leftButtonPressed = true;
    
}

private void OnRightButtonClick()
{
    if (!eventStarted)
    {
        StartEvent(false);
    }
    else
    {
        if (!rightButtonPressed)
        {
            EndEvent(false);
        }
    }

    rightButton.interactable = false;
    rightButtonPressed = true;
    
}


    private void StartEvent(bool isLeft)
{
    eventStarted = true;
    

    if (isLeft)
    {
        leftImage.gameObject.SetActive(true);
        Vector2 targetPosition = new Vector2(-417f, 90f); // Coordenadas X e Y deseadas
        leftHand.rectTransform.anchoredPosition = targetPosition;
        
    }
    else
    {
        rightImage.gameObject.SetActive(true);
        Vector2 targetPosition = new Vector2(417f, -90f); // Coordenadas X e Y deseadas
        rightHand.rectTransform.anchoredPosition = targetPosition;
    }

    leftButton.interactable = true;
    rightButton.interactable = true;

    
}


    private void EndEvent(bool isLeft)
{
    leftButton.interactable = false;
    rightButton.interactable = false;

    if (isLeft)
    {
        // El jugador tocó el lado izquierdo antes de tiempo
        rightImage.gameObject.SetActive(true);
        Vector2 targetPosition = new Vector2(417f, -90f); // Coordenadas X e Y deseadas
        rightHand.rectTransform.anchoredPosition = targetPosition;
        canTap = false;
        
    }
    else
    {
        // El jugador tocó el lado derecho antes de tiempo
        leftImage.gameObject.SetActive(true);
        Vector2 targetPosition = new Vector2(-417f, 90f); // Coordenadas X e Y deseadas
        leftHand.rectTransform.anchoredPosition = targetPosition;
        canTap = false;
    }

    // Restablecer los valores
    warImage.gameObject.SetActive(false);
    canTap = false;
    eventStarted = false;

    nextInterval = GetRandomInterval();
    Invoke("AllowTap", nextInterval);

   
    
}
private void ChangeScene()
{

SceneManager.LoadScene("Juego");

}
    private void AllowTap()
    {
        canTap = true;
        
    }

    private float GetRandomInterval()
    {
        return Random.Range(minInterval, maxInterval);
    }

    
}






