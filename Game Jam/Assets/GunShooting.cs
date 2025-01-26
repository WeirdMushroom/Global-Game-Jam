using UnityEngine;

public class GunShooting : MonoBehaviour
{
    public GameObject bubble;
    public float bubbleSpeed;
    public GameObject projectileSpawnPoint;

    public float fireRate;
    float fireRateTimer;
    void Start()
    {
        
    }

    void Update()
    {
        fireRateTimer += Time.deltaTime;
        if (fireRateTimer > fireRate)
        {
            if (Input.GetMouseButton(0))
            {
                GameObject newBubble = Instantiate(bubble, projectileSpawnPoint.transform.position, Quaternion.identity);
                newBubble.SetActive(true);
                Destroy(newBubble, 3);
                Rigidbody bubbleRB = newBubble.GetComponent<Rigidbody>();
                bubbleRB.AddForce(-transform.up.normalized * bubbleSpeed, ForceMode.Impulse);
            }
            fireRateTimer = 0;
        }
    }
}
