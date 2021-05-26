using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NorthBridgeButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;

    public void NorthBridgeInformation()
    {
        textMesh.text = "Северный мост (англ. north bridge) — системный контроллер (чип), " +
            "являющийся одним из элементов чипсета материнской (системной) платы и отвечающий за работу" +
            " центрального процессора (CPU) с ОЗУ (оперативной памятью, RAM), видеоадаптером";
    }
}
