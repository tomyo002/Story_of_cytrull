using System.Collections;
using UnityEngine;


public class familierSet : MonoBehaviour
{
     public static familierSet instance;
     public int idFami;

     public float moveSpeed;
     public LayerMask collisionLayer;
     public Rigidbody2D Rb;


    public Animator animator;
     public float jumpForce;
     public bool isJumping;
     private int yFamilier = 180;
    public float timeItem = 60;
    public Collider2D colider;

     public SpriteRenderer spriteRenderer;
     private  Vector3 velocity = Vector3.zero;
     public GameObject CharaLoin;
     public Transform groundcheck;
     public GameObject Zfamilier;
     public float GroundCheckRadius;
     public bool isGrounded;
     private float horizontalMovement;
     public Item item;

     public bool isChest;
     public bool isPyr;
     public bool isOursin;
     private void Awake()
  {
    StartCoroutine(itemPoulpe(timeItem));
    StartCoroutine(Maledition());

    if(instance != null)
    {
        Debug.LogWarning("Il y a plus d'une instance de familierSet dans la scene");
        return;
    }
    instance =this;
    
  }
  
    void Update()
    {
         if (idFami ==1)
        {
            isPyr = true;
            isOursin = false;
            isChest = false;
            spriteRenderer.enabled = true;
            colider.enabled = true;
            playerHelth.instance.VieMoins();

        }
        if (idFami ==2)
        {
            isPyr = false;
            isOursin = true;
            isChest = false;
            spriteRenderer.enabled = true;
            colider.enabled = true;
            playerHelth.instance.ViePLus();

        }
        if (idFami ==3)
        {
            isPyr = false;
            isOursin = false;
            isChest = true;
            spriteRenderer.enabled = true;
            colider.enabled = true;
            playerHelth.instance.VieMoins();
            
        }
       
       
         
         animator.SetBool("isChest",isChest);
        animator.SetBool("isPyr",isPyr);
        animator.SetBool("isOursin",isOursin);
            
              Moveplayer(horizontalMovement);
            Flip(Rb.velocity.x);
            
            
        if( isGrounded && Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                isGrounded = false;
            }
        
       horizontalMovement =Input.GetAxis("Horizontal")* moveSpeed * Time.fixedDeltaTime;
        

    }
    void FixedUpdate()
    {
       
       
         if (CharaLoin.transform.position.x- Zfamilier.transform.position.x > 15 | CharaLoin.transform.position.x- Zfamilier.transform.position.x < - 15)
        {
            Zfamilier.transform.position = new Vector3 (CharaLoin.transform.position.x -2 ,CharaLoin.transform.position.y , Zfamilier.transform.position.z);
        }
         if (CharaLoin.transform.position.y- Zfamilier.transform.position.y > 15 | CharaLoin.transform.position.y- Zfamilier.transform.position.y < - 15)
        {
            Zfamilier.transform.position = new Vector3 (CharaLoin.transform.position.x -2,CharaLoin.transform.position.y , Zfamilier.transform.position.z);
        }
        
        isGrounded=Physics2D.OverlapCircle(groundcheck.position, GroundCheckRadius , collisionLayer);
       
        

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
    void Moveplayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2 (_horizontalMovement,Rb.velocity.y);
        Rb.velocity = Vector3.SmoothDamp(Rb.velocity, targetVelocity, ref velocity,.05f);
        
        if (isPyr == true)
        {
             Zfamilier.transform.rotation = Quaternion.Euler (0f,0f,0f);
        }
        else
        {
             Zfamilier.transform.rotation = Quaternion.Euler (0f,yFamilier,0f);
        }

        if (isJumping == true)
            {
                JumpFor(jumpForce);
            }
    }
     private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundcheck.position, GroundCheckRadius );
    }
      public void JumpFor(float _jumpForce)
    {
        
            Rb.AddForce(new Vector2(0f,_jumpForce));
         
            isJumping = false;
        }
    public IEnumerator itemPoulpe(float timeItem)
    {
        yield return new WaitForSeconds(timeItem);
        if (isChest == true)
        {  
        Inventory.instance.content.Add(item);
        Inventory.instance.UpdateInventoryUi();
        
           
        }
        StartCoroutine(itemPoulpe(timeItem));
        
    }
    public void jeTaiChoisi(int valEgg)
    {
        if (valEgg ==1)
        {
            idFami = 1;
        }
        if (valEgg ==2)
        {
            idFami = 2;
        }
        if (valEgg ==3)
        {
            idFami = 3; 
        }
    }
    public IEnumerator Maledition()
    {
           yield return new WaitForSeconds(2);
           if (idFami == 1)
           {

           
           playerHelth.instance.IsInvincible = true;
         StartCoroutine(playerHelth.instance.InvincibilityFlash());
        StartCoroutine( playerHelth.instance.mauditPyramide(1));
           }
    }
}
