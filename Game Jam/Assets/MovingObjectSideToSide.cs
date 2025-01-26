using UnityEngine;

public class MovingObjectSideToSide : MonoBehaviour
{

    public Vector3 position1, position2, position3;

    public float speed1, speed2, speed3;

    bool pos1, pos2, pos3;
    void Start()
    {
        transform.position = position1;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, position1) < 0.5f)
        {
            pos1 = true;
            pos2 = false;
            pos3 = false;
        } else if (Vector3.Distance(transform.position, position2) < 0.5f)
        {
            pos2 = true;
            pos1 = false;
            pos3 = false;
        } else if (Vector3.Distance(transform.position, position3) < 0.5f)
        {
            pos3 = true;
            pos1 = false;
            pos2 = false;
        }
        
        if (pos1)
        {
            transform.position = Vector3.Lerp(transform.position, position2, speed1 * Time.deltaTime);
        }
        if (pos2)
        {
            transform.position = Vector3.Lerp(transform.position, position3, speed2 * Time.deltaTime);
        }
        if (pos3)
        {
            transform.position = Vector3.Lerp(transform.position, position1, speed3 * Time.deltaTime);
        }
    }
}
