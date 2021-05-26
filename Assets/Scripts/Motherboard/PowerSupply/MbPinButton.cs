using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MbPinButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;

    public void MbPinInformation()
    {
        textMeshPro.text = "16pin - разъем для подключения питания материнской платы";
    }
}
