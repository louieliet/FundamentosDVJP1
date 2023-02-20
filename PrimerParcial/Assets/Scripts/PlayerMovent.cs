using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovent : MonoBehaviour
{
    private float horizontalMove;
    private Rigidbody2D player;
    private Animator animator;
    public float speed;
    public float jumpForce;
    private bool Grounded;
    public float distanceGround;
    private bool onFloor;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        //Input
        horizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetBool("Running", horizontalMove != 0.0f);
        animator.SetBool("Ground", Grounded);

        //Rotatio
        if (horizontalMove < 0.0f) transform.localScale = new Vector3(-5.0f,5.0f,5.0f);
        else if (horizontalMove > 0.0f) transform.localScale = new Vector3(5.0f,5.0f,5.0f);
        
        //Moving
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalMove);
        
        //Jumping and Ground
        if(Physics2D.Raycast(transform.position, Vector2.down, distanceGround)){
            Grounded = true;
        }
        else Grounded = false;


        if(Input.GetKeyDown(KeyCode.W) && Grounded){
            Jump();
        }
        
        //Crouching
        if(Input.GetKeyDown(KeyCode.S)){
            Crouch();
        }
    }

    private void Jump(){
        player.velocity = Vector2.up * jumpForce;
    }
    private void Crouch(){
        player.velocity = -Vector2.up * jumpForce;
    }
}
