using UnityEngine;

public class BossBubbleCannon : MonoBehaviour
{
    public bool firstStage;
    BubbleCannonScript regularCannonScript;
    public GameObject bubble, nonBounceBubble, projectileSpawnPoint;
    public float bubbleSpeed;

    [Header("First Stage")]
    public float fireRate1;
    public float rotationSpeed;
    float fireRate1Timer;
    float rotationChangeDelay = 3;
    float rotationChangeTimer;
    float rotationChangeAmount;


    void Start()
    {
        regularCannonScript = GetComponent<BubbleCannonScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (firstStage)
        {
            // Disable normal shooting script
            regularCannonScript.enabled = false;
            // Engage shooting
            fireRate1Timer += Time.deltaTime;
            if (fireRate1Timer > fireRate1)
            {
                Shoot(nonBounceBubble);
                fireRate1Timer = 0;
            }
            // Engage Random Rotation
            rotationChangeTimer += Time.deltaTime;
            if (rotationChangeTimer > rotationChangeDelay)
            {
                rotationChangeAmount = (Random.value * 0.25f) + 1;
                rotationChangeTimer = 0;
            }
            // Rotate
            transform.Rotate(new Vector3(0, 0, (rotationSpeed + rotationChangeAmount) * Time.deltaTime));

        }
    }


    private void Shoot(GameObject bubbleType)
    {
        GameObject newBubble = Instantiate(bubbleType, projectileSpawnPoint.transform.position, Quaternion.identity);
        newBubble.SetActive(true);
        Destroy(newBubble, 5);
        Rigidbody bubbleRB = newBubble.GetComponent<Rigidbody>();
        bubbleRB.AddForce(-transform.up.normalized * bubbleSpeed * (Random.value * 0.25f + 1), ForceMode.Impulse);
    }
}
