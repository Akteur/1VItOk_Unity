using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VrmButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;

    public void VrmInformation()
    {
        textMeshPro.text = "VRM - модуль регулятора напряжения (Voltage Regulator Module), " +
            "является важной, но недооцененной многими частью аппаратного обеспечения компьютера. " +
            "Благодаря ряду электронных компонентов VRM обеспечивает " +
            "стабильное питание вашего ЦПУ или ГПУ постоянным напряжением. " +
            "Некачественная система VRM может привести к снижению производительности и " +
            "ограничить способность процессора работать под нагрузкой. " +
            "Это даже может привести к неожиданным отключениям, особенно в разгоне.";
    }
}
