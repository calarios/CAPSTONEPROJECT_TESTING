//PLAYER SCRIPT

using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    //REQUIRED VARIABLES
    public CapsuleCollider2D capsuleCollider { get; private set; }
    public PlayerMovement movement { get; private set; }
    public DeathAnimation deathAnimation { get; private set; }
    public PlayerSpriteRenderer smallRenderer;
    private PlayerSpriteRenderer activeRenderer;
    public bool dead => deathAnimation.enabled;

    //ACTIVATE COLLIDER, MOVEMENT CONTROLS, DEATH ANIMATION AND RENDER SPRITE OF SMALL MARIO
    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        movement = GetComponent<PlayerMovement>();
        deathAnimation = GetComponent<DeathAnimation>();
        activeRenderer = smallRenderer;
    }

    public void Hit()
    {
        Death();
    }

    public void Death()
    {
        smallRenderer.enabled = false;
        deathAnimation.enabled = true;
    }
}