using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speed;
    public float speedUpperLimit;
    public float speedLowerLimit;
    [SerializeField] float exitLimit;

    private void Start()
    {
        speed = Random.Range(speedLowerLimit, speedUpperLimit);
    }
    private void Update()
    {

        this.gameObject.transform.position += Vector3.down * Time.deltaTime * speed;
        if (this.gameObject.transform.position.y <= exitLimit)
        {
            Destroy(this.gameObject);
         
        }
    }
}
