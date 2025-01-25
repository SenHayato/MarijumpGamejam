using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerType playerType;
    PlayerControls playerControls;
    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime; //How much time the player can hang in the air before jumping
    private float coyoteCounter; //How much time passed since the player ran off the edge

    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    [Header("Sounds")]
    [SerializeField] private AudioClip jumpSound;

    private Rigidbody2D body;
    private Animator anim;
    private Collider2D col2d;
    private float wallJumpCooldown;
    private float horizontalValue;

    private void Awake()
    {
        playerControls = FindAnyObjectByType<PlayerControls>();
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col2d = GetComponent<Collider2D>();
    }
    

    private void Update()
    {
        horizontalValue = (playerType == PlayerType.Player_1) ? playerControls.GetAxis_Player_1() : playerControls.GetAxis_Player_2();

        //Flip player when moving left-right
        if (horizontalValue > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalValue < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        //Set animator parameters
        anim.SetBool("run", horizontalValue != 0);
        anim.SetBool("grounded", isGrounded());

        // Jump
        if (playerType == PlayerType.Player_2 && playerControls.GetJumpPlayer_2())
        {
            Jump();
        }

        //Adjustable jump height
        if (playerType == PlayerType.Player_2 && playerControls.GetJumpPlayer_2() && body.velocity.y > 0)
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);

        if (onWall())
        {
            // body.gravityScale = 1;
            body.velocity = Vector2.zero;
        }
        else
        {
            body.gravityScale = 7;
            body.velocity = new Vector2(horizontalValue * speed, body.velocity.y);

            if (isGrounded())
            {
                coyoteCounter = coyoteTime; //Reset coyote counter when on the ground
            }
            else
                coyoteCounter -= Time.deltaTime; //Start decreasing coyote counter when not on the ground
        }
    }

    private void Jump()
    {
        if (coyoteCounter <= 0 && !onWall()) return; 
        //If coyote counter is 0 or less and not on the wall and don't have any extra jumps don't do anything

        SoundManager.instance.PlaySound(jumpSound);

        // if (onWall())
        //     // WallJump();
        // else
        // {
            
        // }
        if (isGrounded())
                body.velocity = new Vector2(body.velocity.x, jumpPower);
            else
            {
                //If not on the ground and coyote counter bigger than 0 do a normal jump
                if (coyoteCounter > 0)
                    body.velocity = new Vector2(body.velocity.x, jumpPower);
            }

            //Reset coyote counter to 0 to avoid double jumps
            coyoteCounter = 0;
    }

    private void WallJump()
    {
        // body.AddForce(Vector2.down);
        // wallJumpCooldown = 0;
    }


    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(col2d.bounds.center, col2d.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(col2d.bounds.center, col2d.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }
    public bool canAttack()
    {
        return horizontalValue == 0 && isGrounded() && !onWall();
    }

}