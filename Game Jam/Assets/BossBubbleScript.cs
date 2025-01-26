using UnityEngine;

public class BossBubbleScript : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }
}
