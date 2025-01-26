using UnityEngine;

public class SetNewSpawnPoint : MonoBehaviour
{
    public PlayerCollision playerCollisionScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            playerCollisionScript.spawnPoint = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }
    }
}
