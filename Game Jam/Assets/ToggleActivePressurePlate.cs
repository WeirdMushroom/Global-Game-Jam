using UnityEngine;

public class ToggleActivePressurePlate : MonoBehaviour
{

    public GameObject thingToToggle;
    public bool setActive;
    public bool setUnactive;
    public bool toggleActive;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            if (setActive)
            {
                thingToToggle.SetActive(true);
            }
            if (setUnactive)
            {
                thingToToggle.SetActive(false);
            }
            if (toggleActive)
            {
                thingToToggle.SetActive(!thingToToggle.activeSelf);
            }
        }
    }
}
