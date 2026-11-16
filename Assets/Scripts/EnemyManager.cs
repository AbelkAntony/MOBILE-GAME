using Unity.InferenceEngine;
using Unity.Mathematics;
using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject Enemy1;
    [SerializeField] GameObject Enemy2;

    [Header("Spawn Time")]
    public float minimumTime = 2f;
    public float maximumTime = 5f;

    public float timerDuration = 5f;


    private float timer;
    private Vector3 spwanLocation;
    private float[] xPositionList = new float[]{-1.5f,-.5f,.5f,1.5f };
    private float xPosition;
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        timer = timerDuration;
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            // Pick a random time
            float randomTime = UnityEngine.Random.Range(minimumTime, maximumTime);

            // Wait
            yield return new WaitForSeconds(randomTime);

            // Spawn prefab
            int arrayPosition = UnityEngine.Random.Range(0, 4);
            xPosition = xPositionList[arrayPosition];
            spwanLocation = new Vector3(xPosition, this.transform.position.y, this.transform.position.z);
            Instantiate(Enemy1, spwanLocation, this.transform.rotation);
        }
    }
}











