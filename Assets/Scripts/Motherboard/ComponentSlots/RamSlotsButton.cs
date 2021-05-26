using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RamSlotsButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;

    public void RamSlotsInformation()
    {

        textMeshPro.text = "Слоты ОЗУ предназачены для установки оперативных запоминающих устройств (ОЗУ)";
    }
}
