using UnityEngine;
using UnityEngine.UI;

public class AchievementEarned : MonoBehaviour
{
    [SerializeField] Image success;

    public void AchievementEarn(bool earned)
    {
        if (earned)
            success.color = new Color(255, 255, 255, 1);
        else
            success.color = new Color(255, 255, 255, 0);
    }
}
