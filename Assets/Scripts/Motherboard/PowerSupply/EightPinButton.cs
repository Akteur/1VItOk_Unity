using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EightPinButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;

    public void EightPinInformation()
    {
        textMeshPro.text = "8pin - разъем для подключения питания процессора";
    }
}
