using UnityEngine;

public class ObjectScaling : MonoBehaviour
{
    public void Scaling(GameObject scaledObject, GameObject lookHand, float wheelSpeed, float maxDistance, float minDistance)
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scaledObject.transform.localPosition.z <= maxDistance)
        {
            if (scroll > 0.0f)
            {
                scaledObject.transform.position += lookHand.transform.forward * scroll * wheelSpeed;
            }
        }
        if (scaledObject.transform.localPosition.z >= minDistance)
        {
            if (scroll < 0.0f)
            {
                scaledObject.transform.position += lookHand.transform.forward * scroll * wheelSpeed;
            }
        }
    }
}
