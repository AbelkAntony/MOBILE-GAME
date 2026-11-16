
using UnityEngine;

public class CloudMovement : MonoBehaviour
{

    [SerializeField] float horizontalSpeed;
    [SerializeField] float verticalSpeed;

    [SerializeField] float exitLoc;

    [SerializeField] Sprite[] clouds;


    
    void Update()
    {
        this.gameObject.transform.position += Vector3.right * Time.deltaTime * horizontalSpeed;
        this.gameObject.transform.position += Vector3.down * Time.deltaTime * verticalSpeed;
        if(this.gameObject.transform.position.x > exitLoc)
        {
            Destroy(this.gameObject);
        }
    }
}
