using System.Collections;
using UnityEngine;

public class BubbleCannonScript : MonoBehaviour
{
    public GameObject bubble;
    public GameObject projectileSpawnPoint;
    public Rigidbody rb;

    [Header("Shooting Variables")]
    public float fireRate;
    public bool randomFireRateCannon;
    public float bubbleSpeed;
    public float firstShotCooldown;
    float fireRateCounter = 0;


    [Header("Rotating Variables")]
    public bool rotatingCannon;
    float rotationSpeed = 2;
    public float rotationTimerReset;
    float rotationTimer = 0;
    Quaternion randomRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (rotatingCannon)
        {
            randomRotation = Quaternion.Euler(-90, (Random.value - 0.5f) * 720, 0);
        }
        fireRateCounter -= firstShotCooldown;
    }

    // Update is called once per frame
    void Update()
    {

        // Rotation
        if (rotatingCannon)
        {
            rotationTimer += Time.deltaTime;
            if (rotationTimer >= rotationTimerReset)
            {
                rotationTimer = 0;
                randomRotation = Quaternion.Euler(-90, (Random.value - 0.5f) * 720, 0);
            }
            transform.rotation = Quaternion.Lerp(transform.rotation, randomRotation, Time.deltaTime * rotationSpeed);
        }

        // Shooting
        fireRateCounter += Time.deltaTime;
        if (fireRateCounter >= fireRate)
        {
            GameObject newBubble = Instantiate(bubble, projectileSpawnPoint.transform.position, Quaternion.identity);
            newBubble.SetActive(true);
            Destroy(newBubble, 5);
            Rigidbody bubbleRB = newBubble.GetComponent<Rigidbody>();
            bubbleRB.AddForce(-transform.up.normalized * bubbleSpeed, ForceMode.Impulse);
            if (randomFireRateCannon)
            {
                fireRateCounter = 0 + Random.value;
            } else
            {
                fireRateCounter = 0;
            }
        }

    }
}
