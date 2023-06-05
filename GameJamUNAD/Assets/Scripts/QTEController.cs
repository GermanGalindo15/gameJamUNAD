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
    public RawImage instructions;
   
    

    private bool leftButtonPressed = false;
    private bool rightButtonPressed = false;

    public float delay = 5f;

    [Range (5f, 7f)]
    public float minInterval = 5f;

    [Range (10f, 13f)]
    public float maxInterval = 12f;

    private bool canTap = false;
    private bool eventStarted = false;

    private float nextInterval;

    private void Start()
    {
        

        nextInterval = GetRandomInterval();
        Invoke("AllowTap", nextInterval);

        

        instructions.gameObject.SetActive(true);

        rightImage.gameObject.SetActive(false);
        leftImage.gameObject.SetActive(false);
        warImage.gameObject.SetActive(false);

        
    }

    private void Update()
    {
        if (canTap)
        {

            leftButton.onClick.AddListener(OnLeftButtonClick);
            rightButton.onClick.AddListener(OnRightButtonClick);

            warImage.gameObject.SetActive(true);
            instructions.gameObject.SetActive(false);
    
        }
        
        if(leftButtonPressed == true)
        {
            warImage.gameObject.SetActive(false);
            instructions.gameObject.SetActive(false);
            Invoke("ChangeScene", delay);
        }
        else if(rightButtonPressed == true)
        {
            warImage.gameObject.SetActive(false);
            instructions.gameObject.SetActive(false);
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






