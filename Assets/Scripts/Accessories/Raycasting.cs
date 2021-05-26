using UnityEngine;

public class Raycasting : MonoBehaviour
{
    RaycastHit hit;
    public GameObject raycastedObject;
    public bool succesful;
    void Update()
    {
        Vector3 direction = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, direction, out hit, 5) && hit.collider.GetComponent<Name>())
        {
            raycastedObject = hit.collider.gameObject;
            succesful = true;
        }
        else
        {
            succesful = false;
        }
    }
}
