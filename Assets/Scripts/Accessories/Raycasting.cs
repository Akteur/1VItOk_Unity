using UnityEngine;

public class Raycasting : MonoBehaviour
{
    [SerializeField] float distance = 3;
    RaycastHit hit;
    public GameObject raycastedObject;
    public bool succesful;
    void Update()
    {
        Vector3 direction = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, direction, out hit, distance) && hit.collider.GetComponent<Name>())
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
