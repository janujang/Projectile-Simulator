using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.Unity.InputModule;

public class InputFieldClick : MonoBehaviour
{
    public Button speedButton;
    public Button angleButton;
    public Text speedText;
    public Text angleText;

    public void SetNumPadToSpeed()
    {
        angleButton.image.color = Color.white;
        NumPadController.UseNumPad(speedText, speedButton);
    }

    public void SetNumPadToAngle()
    {
        speedButton.image.color = Color.white;
        NumPadController.UseNumPad(angleText, angleButton);
    }
}
