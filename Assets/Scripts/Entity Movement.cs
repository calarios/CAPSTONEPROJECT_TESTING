//GOOMBA MOVEMENT
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EntityMovement : MonoBehaviour
{
    //SPEED/DIRECTION OF GOOMBA
    public float speed = 1f;
    public Vector2 direction = Vector2.left;

    //RIGID BODY
    private Rigidbody2D rb;
    private Vector2 velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enabled = false;
    }

    //GOOMBA ACTION WHEN ON VIEW
    private void OnBecameVisible()
    {
#if UNITY_EDITOR
        enabled = !EditorApplication.isPaused;
#else
        enabled = true;
#endif
    }

    // WHEN DESTROYED
    private void OnBecameInvisible()
    {
        enabled = false;
    }

    //MOVEMENTS ACTIVATED
    private void OnEnable()
    {
        rb.WakeUp();
    }

    //RB SLEEP
    private void OnDisable()
    {
        rb.velocity = Vector2.zero;
        rb.Sleep();
    }

    //DIRECTION ON FIXED UPDATE
    private void FixedUpdate()
    {
        velocity.x = direction.x * speed;
        velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        if (rb.Raycast(direction))
        {
            direction = -direction;
        }

        if (rb.Raycast(Vector2.down))
        {
            velocity.y = Mathf.Max(velocity.y, 0f);
        }

        if (direction.x > 0f)
        {
            transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if (direction.x < 0f)
        {
            transform.localEulerAngles = Vector3.zero;
        }
    }

}