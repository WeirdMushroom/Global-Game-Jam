using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public BossFightStart bossFightStartScript;
    public BossScript bossScript;
    public Rigidbody rb;
    public Vector3 spawnPoint;
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
            if (bossFightStartScript.bossFightStarted)
            {
                bossScript.health = 100;
            }
        }
    }
    public void die()
    {
        transform.position = spawnPoint;
        rb.linearVelocity = Vector3.zero;
        if (bossFightStartScript.bossFightStarted)
        {
            bossScript.health = 100;
        }
    }

}
