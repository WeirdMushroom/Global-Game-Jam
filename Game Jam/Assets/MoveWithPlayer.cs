using UnityEngine;

public class MoveWithPlayer : MonoBehaviour
{
    public GameObject cameraPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPosition.transform.position;
    }
}
