using UnityEngine;

public class BossFightStart : MonoBehaviour
{
    public GameObject cannons, mainCannon;
    public GameObject boss;
    public GameObject castle;
    public GameObject gun;
    public GameObject removableObjects, bossHealthBar;

    bool summonCastle;
    public bool bossFightStarted;
    void Update()
    {
        if (summonCastle)
        {
            castle.SetActive(true);
            castle.transform.position = Vector3.Lerp(castle.transform.position, new Vector3(castle.transform.position.x, 70, castle.transform.position.z), Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            bossFightStarted = true;
            removableObjects.SetActive(false);
            mainCannon.SetActive(true);
            gun.SetActive(true);
            cannons.SetActive(false);
            boss.SetActive(true);
            bossHealthBar.SetActive(true);
            summonCastle = true;
        }
    }
}
