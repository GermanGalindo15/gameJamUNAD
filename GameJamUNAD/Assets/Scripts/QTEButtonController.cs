using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEButtonController : MonoBehaviour
{
    public QTEController qteController;

    private void OnMouseDown()
    {
        if (qteController.IsTouched())
        {
            if (qteController.IsTouchedLeft())
            {
                Debug.Log("Touched left side");
                // Realiza las acciones correspondientes si se toca la mitad izquierda
            }
            else if (qteController.IsTouchedRight())
            {
                Debug.Log("Touched right side");
                // Realiza las acciones correspondientes si se toca la mitad derecha
            }
        }
    }
}

