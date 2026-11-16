using UnityEngine;
using System.Collections;

public class CloudManager : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject prefabToSpawn;

    public Sprite[] cloudSpriteList;
    private int cloudSpriteListLength;
    [Header("Spawn Time")]
    public float minimumTime = 2f;
    public float maximumTime = 5f;

    [Header("Spawn Position")]
    public Transform spawnPoint;

    private GameObject cloud;
    private Sprite cloudSprite;
    private void Start()
    {
        StartCoroutine(SpawnRoutine());
        cloudSpriteListLength = cloudSpriteList.Length;
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            // Pick a random time
            float randomTime = Random.Range(minimumTime, maximumTime);

            // Wait
            yield return new WaitForSeconds(randomTime);

            // Spawn prefab
            cloud = Instantiate(prefabToSpawn,spawnPoint.position, spawnPoint.rotation);
            cloudSprite = cloudSpriteList[Random.Range(0, cloudSpriteListLength)];
            cloud.GetComponent<SpriteRenderer>().sprite = cloudSprite;
        }
    }
}
