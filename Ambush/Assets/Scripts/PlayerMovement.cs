using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {
        //Grab references from rigidbody and animator from object  
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        
    }

    private void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalInput * speed,body.velocity.y);
 
        //Flip player when moving horizontally
        if(horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1,1,1);
        

        if(Input.GetKey(KeyCode.Space) && grounded)  //allow player to jump only when its grounded
            Jump();

        //Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    //when some component with rigidbody touches with the other object which has rigidbody
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Ground")
            grounded = true;
        
    }









/*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
*/

}
