using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Rigidbody rb;
    public PlayerMovement movementScript;
    Vector3 spawnPoint;
    private void Awake()
    {
        spawnPoint = new Vector3(0, 30, -26);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            transform.position = spawnPoint;
            rb.linearVelocity = Vector3.zero;
        }
    }
}
