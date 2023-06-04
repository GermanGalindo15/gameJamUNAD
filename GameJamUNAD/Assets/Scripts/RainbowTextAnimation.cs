using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RainbowTextAnimation : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMeshPro;
    
    [SerializeField]
    private Gradient outlineGradient;
    
    [SerializeField]
    private float duration = 1f;

    private float timer;

    private void Start()
    {
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        
        // Calcula la posición normalizada en la animación
        float t = timer / duration;
        
        // Aplica el degradado de colores al borde y al brillo
        textMeshPro.outlineColor = outlineGradient.Evaluate(t);
        

        // Si la animación ha completado una iteración, reinicia el temporizador
        if (timer >= duration)
        {
            timer = 0f;
        }
    }
}
