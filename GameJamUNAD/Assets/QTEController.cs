using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEController : MonoBehaviour
{
    private bool isQTEActive = false;
    private bool isTouched = false;
    private bool isTouchedLeft = false;
    private bool isTouchedRight = false;

    private void Update()
    {
        if (isQTEActive)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                
                if (touch.phase == TouchPhase.Began)
                {
                    isTouched = true;
                    isTouchedLeft = touch.position.x < Screen.width / 2f;
                    isTouchedRight = touch.position.x >= Screen.width / 2f;
                }
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                {
                    isTouched = false;
                }
            }
        }
    }

    public void StartQTE()
    {
        isQTEActive = true;
    }

    public void StopQTE()
    {
        isQTEActive = false;
        isTouched = false;
        isTouchedLeft = false;
        isTouchedRight = false;
    }

    public bool IsTouched()
    {
        return isTouched;
    }

    public bool IsTouchedLeft()
    {
        return isTouchedLeft;
    }

    public bool IsTouchedRight()
    {
        return isTouchedRight;
    }
}

