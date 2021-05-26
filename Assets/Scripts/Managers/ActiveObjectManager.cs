using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjectManager : MonoBehaviour
{
    void Awake()
    {
        if(gameObject.activeInHierarchy == false)
        {
            gameObject.GetComponent<SlotEmptyState>().slotEmpty = true;
        }
    }
}
