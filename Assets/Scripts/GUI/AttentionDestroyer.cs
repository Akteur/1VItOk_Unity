using System.Collections;
using TMPro;
using UnityEngine;

public class AttentionDestroyer : MonoBehaviour
{
    GameObject attentionTextGO;
    TextMeshProUGUI attentionTextMeshPro;
    private bool saving;
    void Start()
    {
        saving = false;
        attentionTextGO = GameObject.Find("AttentionText (TMP)");
        attentionTextMeshPro = attentionTextGO.GetComponent<TextMeshProUGUI>();
        if (GameManager.instance.authScene)
        {
            if (!GameManager.instance.GetUniquePlayerState())
            {
                attentionTextMeshPro.text = "Имя занято!";
            }
            if(GameManager.instance.GetEmptyAuthDataState())
            {
                attentionTextMeshPro.text = "Введите логин и пароль!";
            }
        }
        if (GameManager.instance.mainScene)
        {
            attentionTextMeshPro.text = "Aвторизируйтесь!";
            saving = true;
        }
        if (!GameManager.instance.playerExist && !GameManager.instance.registration && !saving)
        {
            attentionTextMeshPro.text = "Игрок не существует!";
        }
        StartCoroutine(AttentionDestroy());
    }

    IEnumerator AttentionDestroy()
    {
        yield return new WaitForSeconds(3f);
        GameManager.instance.attentionInstantieted = false;
        Destroy(gameObject);
    }
}
