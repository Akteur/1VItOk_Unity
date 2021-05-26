using TMPro;
using UnityEngine;

public class PcieButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;

    public void PcieInformation()
    {
        textMeshPro.text = "PCI и PCIE - слоты для установки карт расширений, например видеокарты или звуковой карты.";
    }
}
