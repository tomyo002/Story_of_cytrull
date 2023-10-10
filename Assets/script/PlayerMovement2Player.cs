using System.Collections;

using UnityEngine;

public class PlayerMovement2Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;



    private bool isJumping;
    private bool isGrounded;
    [HideInInspector]
    public bool isClimbing;

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


    public static PlayerMovement2Player instance;
  
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement2Player dans la scene");
            return;
        }
        instance =this;
    }

    void Update()
    {
        horizontalMovement =Input.GetAxis("Horizontal")* moveSpeed * Time.fixedDeltaTime;

        
        
        float characterVelocity = Mathf.Abs(Rb.velocity.x);
        animator.SetFloat("Speed",characterVelocity);


       
         if( isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
        Flip(Rb.velocity.x);
    }

   
    
    void FixedUpdate()
    {
        isGrounded=Physics2D.OverlapCircle(groundcheck.position, GroundCheckRadius , collisionLayer);
        Moveplayer(horizontalMovement);

        
        
    }
    void Moveplayer(float _horizontalMovement)
    {
       
            Vector3 targetVelocity = new Vector2 (_horizontalMovement,Rb.velocity.y);
            Rb.velocity = Vector3.SmoothDamp(Rb.velocity, targetVelocity, ref velocity,.05f);

            if (isJumping == true)
            {
                JumpFor(jumpForce);
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
      
            Rb.AddForce(new Vector2(0f,jumpForce));
            
            isJumping = false;

        
    }
    
  
}