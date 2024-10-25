using System.Collections;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite deadSprite;

    //RESETS SPRITE WHEN DEATH
    private void Reset()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //DURING DEATH ANIMATION
    private void OnEnable()
    {
        UpdateSprite();
        DisablePhysics();
        StartCoroutine(Animate());
    }

    // STOP EVERYTHING DURING DEATH ANIMATION
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    // APPLY SPRITES WHEN NECESSARY
    private void UpdateSprite()
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sortingOrder = 10;

        if (deadSprite != null)
        {
            spriteRenderer.sprite = deadSprite;
        }
    }

    //DISABLE PHYSICS
    private void DisablePhysics()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();

        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = false;
        }

        if (TryGetComponent(out Rigidbody2D rigidbody))
        {
            rigidbody.isKinematic = true;
        }

        if (TryGetComponent(out PlayerMovement playerMovement))
        {
            playerMovement.enabled = false;
        }

        if (TryGetComponent(out EntityMovement entityMovement))
        {
            entityMovement.enabled = false;
        }
    }

    //DEATH ANIMATION
    private IEnumerator Animate()
    {
        float elapsed = 0f;
        float duration = 3f;

        float jumpVelocity = 10f;
        float gravity = -36f;

        Vector3 velocity = Vector3.up * jumpVelocity;

        while (elapsed < duration)
        {
            transform.position += velocity * Time.deltaTime;
            velocity.y += gravity * Time.deltaTime;
            elapsed += Time.deltaTime;
            yield return null;
        }
        GameManager.Instance.ResetLevel();
    }

}