using UnityEngine;

public class SpecialPressurePlate2 : MonoBehaviour
{
    public bool activated2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            activated2 = true;
        }
    }
}
