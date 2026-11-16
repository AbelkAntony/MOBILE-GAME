using UnityEngine;

public class RoadMovement : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float exitLimit;

    private void Update()
    {
        this.gameObject.transform.position += Vector3.down * Time.deltaTime * speed ;
        if (this.gameObject.transform.position.y <= exitLimit)
        {
            this.transform.position = new Vector3(this.transform.position.x, 7, this.transform.position.z);
        }
    }
}
