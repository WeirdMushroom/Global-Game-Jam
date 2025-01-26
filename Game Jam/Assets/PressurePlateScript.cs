using UnityEngine;

public class PressurePlateScript : MonoBehaviour
{
    public GameObject thingToRotate;
    bool rotate;
    public float degreeToRotateTo;

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            thingToRotate.transform.rotation = Quaternion.Lerp(thingToRotate.transform.rotation, Quaternion.Euler(0, degreeToRotateTo, 0), Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            rotate = true;
        }
    }
}
