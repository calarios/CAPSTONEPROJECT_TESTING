using UnityEngine;

//GOOMBA PHYSICS

public class Goomba : MonoBehaviour
{
    public Sprite flatSprite;

    //PHYSICS APPLIED BASED ON IF PLAYER STOMP GOOMBA OR IF GOOMBA HITS PLAYER
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.TryGetComponent(out Player player))
        {
            if (collision.transform.DotTest(transform, Vector2.down))
            {
                Flatten();
            }
            else
            {
                player.Hit();
            }
        }
    }

    //FLATTEN ANIMATION
    private void Flatten()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EntityMovement>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = flatSprite;
        Destroy(gameObject, 0.5f);
    }

    //HIT PLAYER
    private void Hit()
    {
        GetComponent<DeathAnimation>().enabled = true;
        Destroy(gameObject, 3f);
    }

}