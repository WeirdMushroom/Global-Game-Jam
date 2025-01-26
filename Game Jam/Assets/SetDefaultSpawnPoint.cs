using Unity.VisualScripting;
using UnityEngine;

public class SetDefaultSpawnPoint : MonoBehaviour
{
    public PlayerCollision playerCollisionScript;
    public GameObject player;
    public bool sendToSpawnInstantly;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            playerCollisionScript.spawnPoint = new Vector3(0, 30, -26);
            if (sendToSpawnInstantly)
            {
                player.transform.position = new Vector3(0, 30, -26);
            }
        }
    }
}
