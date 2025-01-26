using UnityEngine;

public class VanishAndComeBack : MonoBehaviour
{
    public MeshRenderer thingToVanish1;
    public MeshRenderer thingToVanish2;
    public MeshRenderer thingToVanish3;
    public MeshRenderer thingToVanish4;
    public float timeInBetween;
    float timer;
    bool start;
    private void Update()
    {
        if (start)
        {
            timer += Time.deltaTime;
            if (timer > timeInBetween * 5)
            {
                thingToVanish4.enabled = false;
                start = false;
                timer = 0;
            } else if (timer > timeInBetween * 4)
            {
                thingToVanish3.enabled = false;
                thingToVanish4.enabled = true;
            }
            else if (timer > timeInBetween * 3)
            {
                thingToVanish2.enabled = false;
                thingToVanish3.enabled = true;
            }
            else if (timer > timeInBetween * 2)
            {
                thingToVanish1.enabled = false;
                thingToVanish2.enabled = true;
            }
            else if (timer > timeInBetween * 1)
            {
                thingToVanish1.enabled = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            start = true;
        }
    }
}
