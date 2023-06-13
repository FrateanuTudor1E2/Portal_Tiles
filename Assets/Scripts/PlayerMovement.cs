using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;
    public GameObject PortalGun;
    public SpriteRenderer gunsprite;
    private float dirX = 0f;
    private Vector2 mousePos;
    public Transform playerX;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    [SerializeField] private LayerMask jumpableGround;
    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>(); 
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        gunsprite = PortalGun.GetComponent<SpriteRenderer>();
     
    }


    
    // Update is called once per frame
    private void Update()
    {
        playerX = GetComponent<Transform>();
        dirX = Input.GetAxisRaw("Horizontal");
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);



        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
             jumpSoundEffect.Play();
             rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }
  
        UpdateAnimationState();
        
    }

    private void UpdateAnimationState()
    {

        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;


        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;

        }
        else
        {
            state = MovementState.idle;
            if (playerX.position.x < mousePos.x)
            {

                sprite.flipX = false;
            }
            else if (playerX.position.x > mousePos.x)
            {

                sprite.flipX = true;
            }

        }
        if (playerX.position.x < mousePos.x)
        {
            gunsprite.flipY = false;
        }
        else if (playerX.position.x > mousePos.x)
        {
            gunsprite.flipY = true;
        }
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
            if (dirX > 0f)
            {
                sprite.flipX = false;
            }
            else if (dirX < 0f)
            {
                sprite.flipX = true;
            }
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
            if (dirX > 0f)
            {
                sprite.flipX = false;
            }
            else if (dirX < 0f)
            {
                sprite.flipX = true;
            }

        }
        if (dirX > 0f)
        {
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            sprite.flipX = true;
        }
        anim.SetInteger("state", (int)state );
    }
    private bool IsGrounded()
    {
  
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
        
    }
}
