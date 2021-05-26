using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttentionDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator AchievementDestroy()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
        StopCoroutine(AchievementDestroy());
    }
}
