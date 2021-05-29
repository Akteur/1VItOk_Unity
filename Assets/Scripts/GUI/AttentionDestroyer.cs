using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttentionDestroyer : MonoBehaviour
{
    GameObject attentionTextGO;
    TextMeshProUGUI attentionTextMeshPro;
    void Start()
    {
        attentionTextGO = GameObject.Find("AttentionText (TMP)");
        attentionTextMeshPro = attentionTextGO.GetComponent<TextMeshProUGUI>();
        if (!GameManager.instance.GetUniquePlayerState())
        {
            attentionTextMeshPro.text = "Имя занято!";
        }
        if (GameManager.instance.GetEmptyAuthDataState())
        {
            attentionTextMeshPro.text = "Введите логин и пароль!";
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
