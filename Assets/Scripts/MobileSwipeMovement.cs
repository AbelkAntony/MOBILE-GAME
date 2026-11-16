using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class MobileSwipeMovement : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [Header("Movement")]
    public float leftDistance = 2f;
    public float rightDistance = 2f;
    public float upDistance = 2f;
    public float downDistance = 2f;

    [Header("Swipe")]
    public float minimumSwipeDistance = 15f;

    [Header("Boundaries")]
    public float minX = -8f;
    public float maxX = 8f;
    public float minY = -4f;
    public float maxY = 4f;

    [Header("Sprites")]
    public Sprite playerLeft;
    public Sprite playerRight;
    public Sprite player;

    public float spriteDelay = 0.15f;

    private Vector2 startPosition;
    private bool trackingSwipe;
    private bool swipeDone;

    private SpriteRenderer playerSprite;


    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }


    private void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();

        playerSprite.sprite = player;
    }


    private void Update()
    {
        if (Touch.activeTouches.Count == 0)
            return;

        Touch touch = Touch.activeTouches[0];


        // --------------------------------
        // FINGER DOWN
        // --------------------------------

        if (touch.phase == UnityEngine.InputSystem.TouchPhase.Began)
        {
            startPosition = touch.screenPosition;

            trackingSwipe = true;
            swipeDone = false;
        }


        // --------------------------------
        // FINGER MOVING
        // --------------------------------

        if (touch.phase == UnityEngine.InputSystem.TouchPhase.Moved)
        {
            if (!trackingSwipe || swipeDone)
                return;

            Vector2 currentPosition = touch.screenPosition;

            Vector2 swipe = currentPosition - startPosition;


            // Wait until finger moves enough
            if (swipe.magnitude < minimumSwipeDistance)
                return;


            // Execute immediately
            swipeDone = true;

            ExecuteSwipe(swipe);
        }


        // --------------------------------
        // FINGER RELEASE
        // --------------------------------

        if (touch.phase == UnityEngine.InputSystem.TouchPhase.Ended ||
            touch.phase == UnityEngine.InputSystem.TouchPhase.Canceled)
        {
            trackingSwipe = false;
            swipeDone = false;
        }
    }


    private void ExecuteSwipe(Vector2 swipe)
    {
        // Horizontal
        if (Mathf.Abs(swipe.x) > Mathf.Abs(swipe.y))
        {
            if (swipe.x > 0)
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }
        }

        // Vertical
        else
        {
            if (swipe.y > 0)
            {
                MoveUp();
            }
            else
            {
                MoveDown();
            }
        }
    }


    private void MoveLeft()
    {
        playerSprite.sprite = playerLeft;

        MovePlayer(Vector2.left, leftDistance);

        CancelInvoke(nameof(SpriteReset));
        Invoke(nameof(SpriteReset), spriteDelay);
    }


    private void MoveRight()
    {
        playerSprite.sprite = playerRight;

        MovePlayer(Vector2.right, rightDistance);

        CancelInvoke(nameof(SpriteReset));
        Invoke(nameof(SpriteReset), spriteDelay);
    }


    private void MoveUp()
    {
        MovePlayer(Vector2.up, upDistance);
    }


    private void MoveDown()
    {
        MovePlayer(Vector2.down, downDistance);
    }


    private void MovePlayer(Vector2 direction, float distance)
    {
        Vector2 newPosition =
            (Vector2)transform.position + direction * distance;


        // Boundaries
        newPosition.x = Mathf.Clamp(
            newPosition.x,
            minX,
            maxX
        );

        newPosition.y = Mathf.Clamp(
            newPosition.y,
            minY,
            maxY
        );


        // Instant movement
        transform.position = newPosition;
    }


    private void SpriteReset()
    {
        playerSprite.sprite = player;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Score"))
        {
            gameManager.AddScore();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            gameManager.GameOver();
        }
    }
}