using UnityEngine;

public class RedBubbleDeathScript : MonoBehaviour
{
    public PlayerCollision playerCollisionScript;
    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.layer == 10)
            {
                playerCollisionScript.die();
            }
    }
}
