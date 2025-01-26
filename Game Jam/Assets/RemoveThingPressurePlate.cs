using UnityEngine;
using UnityEngine.UIElements;

public class RemoveThingPressurePlate : MonoBehaviour
{
    public GameObject thingToRemove;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            thingToRemove.SetActive(false);
        }
    }
}
