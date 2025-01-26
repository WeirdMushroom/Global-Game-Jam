using Unity.VisualScripting;
using UnityEngine;

public class EntryWhenPressurePlates : MonoBehaviour
{
    public SpecialPressurePlate1 Plate1;
    public SpecialPressurePlate2 Plate2;
    public GameObject thingToActivate;
    bool triggered = false;
    private void Update()
    {
        if (!triggered && Plate1.activated1 && Plate2.activated2)
        {
            thingToActivate.SetActive(!thingToActivate.activeSelf);
            triggered = true;
        }
    }
}
