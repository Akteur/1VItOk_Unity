using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SataButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;

    public void SataInformation()
    {
        textMeshPro.text = "SATA - разъем для подключения HDD и SSD дисков с интерфейсом подключения SATA";
    }
}
