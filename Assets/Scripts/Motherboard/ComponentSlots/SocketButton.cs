using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SocketButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;

    public void SocketInformation()
    {
        textMeshPro.text = "Сокет - разъем в материнской плате, предназначенный для установки процессора." +
            "\nСокеты для процессоров AMD: AM4, AM3, AM3+, FM2" +
            "\nСокеты для процессоров Intel: LGA1151, LGA1151v2, LGA1150, LGA1200";
    }
}
