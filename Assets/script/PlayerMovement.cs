using System.Collections;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float climbSpeed;
    public float jumpForce;
    public float jumpForce2;
    private bool jumpPotionFix = false ;
    public SpriteRenderer particuleJump;
    public float jumpForceTrampoline;

    public bool isJumping;
    public bool isGrounded;
    [HideInInspector]
    public bool isClimbing;
    public bool isEffectPoulpe;
    public SpriteRenderer effectParticule;

    public Transform groundcheck;
    public float GroundCheckRadius;
    public LayerMask collisionLayer;

    public Rigidbody2D Rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D playerCollider;

    private Vector3 velocity= Vector3.zero;
    private float horizontalMovement;
    private float VerticalMovement;
    public bool isEcrireReponse = false;

    public static PlayerMovement instance;
  
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scene");
            return;
        }
        instance =this;
    }

    void Update()
    {
        if (isEcrireReponse == false)
        {
            horizontalMovement =Input.GetAxis("Horizontal")* moveSpeed * Time.fixedDeltaTime;
            VerticalMovement =Input.GetAxis("Vertical")* climbSpeed * Time.fixedDeltaTime;
        }
        
        float characterVelocity = Mathf.Abs(Rb.velocity.x);
        animator.SetFloat("Speed",characterVelocity);
        animator.SetBool("isClimbing",isClimbing);

       
         if( isGrounded && Input.GetButtonDown("Jump")&& !isClimbing)
        {
            if(isEcrireReponse == false)
            {
                 isJumping = true;
            }
        }
        Flip(Rb.velocity.x);
        if (isEffectPoulpe == true)
        {
            effectParticule.enabled = true;
        }
        else
        {
            effectParticule.enabled = false;
        }
    }

    public  void TakeJump()
    {
        jumpPotionFix = true;
        particuleJump.enabled = true;
        
    }
    
    void FixedUpdate()
    {
        isGrounded=Physics2D.OverlapCircle(groundcheck.position, GroundCheckRadius , collisionLayer);
        Moveplayer(horizontalMovement, VerticalMovement);

        
        
    }
    void Moveplayer(float _horizontalMovement, float _VerticalMovement)
    {
        if (isClimbing == false)
        {
            Vector3 targetVelocity = new Vector2 (_horizontalMovement,Rb.velocity.y);
            Rb.velocity = Vector3.SmoothDamp(Rb.velocity, targetVelocity, ref velocity,.05f);

            if (isJumping == true)
            {
                JumpFor(jumpForce);
            }
        }else
        {
            // deplacement vertical
            Vector3 targetVelocity = new Vector2 (0, _VerticalMovement);
            Rb.velocity = Vector3.SmoothDamp(Rb.velocity, targetVelocity, ref velocity,.05f);

        }
        
    }
    
    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
         
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundcheck.position, GroundCheckRadius );
    }

     void JumpFor(float _jumpForce)
    {
        if(jumpPotionFix == true)
        {
             Rb.AddForce(new Vector2(0f,jumpForce2));
            jumpPotionFix = false;
            particuleJump.enabled = false;
            isJumping = false;
        }else
        {
            Rb.AddForce(new Vector2(0f,jumpForce));
            
            isJumping = false;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
   {
       if(collision.CompareTag("TrampolineWeak"))
       {
           Rb.AddForce(new Vector2(0f,jumpForceTrampoline));
       }
   }
   
  
}

