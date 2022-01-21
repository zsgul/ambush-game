using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;
    public AudioSource sesKontrol;
    public AudioClip ziplama;

    void Start()
    {
        sesKontrol = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        //Taking references from rigidbody and animator from object  
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();   
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal");

        
        //Flip player when moving horizontally
        if(horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1,1,1);


        //Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        //Wall jump logic
        if(wallJumpCooldown > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed,body.velocity.y);
            
            //allow player to jump only when its grounded

            if(onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 3;

            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
                sesKontrol.PlayOneShot(ziplama, 0.5f);
            } 
        }
        else
            wallJumpCooldown += Time.deltaTime;

    }


    private void Jump()
    {
        

        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if(onWall() && !isGrounded())
        {
            if(horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0 ); //+ facing right, - facing left on x coordinate //- before mathf is there for to change player's facing way
                body.velocity = new Vector3(-Mathf.Sign(transform.localScale.x),transform.localScale.y, transform.localScale.z ); //+ facing right, - facing left on x coordinate //- before mathf is there for to change player's facing way

            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6 ); //+ facing right, - facing left on x coordinate //- before mathf is there for to change player's facing way
        
            wallJumpCooldown = 0;
            
        }
   
    }

   

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    
}
