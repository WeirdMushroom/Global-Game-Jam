using UnityEngine;

public class SpecialPressurePlate1 : MonoBehaviour
{
    public bool activated1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            activated1 = true;
        }
    }
}
