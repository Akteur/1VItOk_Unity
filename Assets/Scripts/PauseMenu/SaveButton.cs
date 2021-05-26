using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    [SerializeField] GameObject player;
    public void Save()
    {
        PlayerData playerData = player.GetComponent<PlayerData>();
        SaveSystem.Save(playerData);
    }
}
