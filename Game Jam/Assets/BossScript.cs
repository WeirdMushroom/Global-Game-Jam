using UnityEngine;
using UnityEngine.UI;
public class BossScript : MonoBehaviour
{
    public GameObject player, bubbleCannon, duplicateBubble, blockingBubble, bossCannons, mainCannon;
    public BossBubbleCannon bubbleCannonScript;
    public PlayerCollision playerCollisionScript;
    public Transform front, center, back, castleSide, spawnSide;
    public Rigidbody rb;
    public Collider hitbox;
    public float health;
    public Image healthbar;

    [Header("Dashing Stage")]
    public float dashSpeed;
    float dashCycleTimer;
    bool readyToDash;
    bool readyToReturn;

    void Start()
    {
        health = 100;
        transform.position = back.position;
        readyToReturn = true;
        readyToDash = true;
    }


    void Update()
    {
        healthbar.fillAmount = health / 100;
        if (health == 100)
        {
            bossCannons.SetActive(true);
            transform.position = back.position;
            bubbleCannonScript.firstStage = false;
        }
        if (health <= 65)
        {
            dashCycleTimer += Time.deltaTime;
            if (dashCycleTimer > 2 && readyToDash)
            {
                dash();
                readyToDash = false;
                readyToReturn = true;
            }
            if (dashCycleTimer > 4 && readyToReturn)
            {
                returnToRandomLocation();
                readyToReturn = false;
                readyToDash = true;
                dashCycleTimer = 0;
            }
        }
        else if (health <= 80)
        {
            bossCannons.SetActive(false);
            hitbox.enabled = false;
            transform.position = Vector3.Lerp(transform.position, center.position + new Vector3(0, 3, 0), Time.deltaTime);
            bubbleCannonScript.firstStage = true;
            Invoke(nameof(toggleHitbox), 5);
        }
    }
    private void dash()
    {
        GameObject newBubble = Instantiate(duplicateBubble, transform.position, Quaternion.identity);
        newBubble.SetActive(true);
        Destroy(newBubble, 3);
        Rigidbody bubbleRB = newBubble.GetComponent<Rigidbody>();
        Vector3 directionToPlayer = player.transform.position - transform.position;
        bubbleRB.AddForce(directionToPlayer.normalized * dashSpeed, ForceMode.Impulse);
    }
    private void returnToRandomLocation()
    {
        float randomLocation = Random.Range(0, 5);
        if (randomLocation == 0)
        {
            transform.position = back.position + new Vector3(0, 10, 0);
        } else if (randomLocation == 1)
        {
            transform.position = center.position + new Vector3(0, 10, 0);
        } else if (randomLocation == 2)
        {
            transform.position = center.position + new Vector3(0, 10, 0);
        } else if (randomLocation == 3)
        {
            transform.position = spawnSide.position + new Vector3(0, 10, 0);
        }
        else if (randomLocation == 4)
        {
            transform.position = castleSide.position + new Vector3(0, 10, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
            health -= 1;
            if (health <= 0)
            {
                Destroy(blockingBubble, 5);
                Destroy(bossCannons);
                Destroy(mainCannon);
                Destroy(gameObject);
            }
        }
        if (other.gameObject.layer == 10)
        {
            playerCollisionScript.die();
        }
    }

    private void toggleHitbox()
    {
        hitbox.enabled = true;
    }
}
