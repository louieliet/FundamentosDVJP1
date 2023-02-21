using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{
    private float horizontalMove;
    private Rigidbody2D player;
    private BoxCollider2D playercollider;
    private Animator animator;
    public float speed;
    public float jumpForce;
    private bool Grounded;
    public float distanceGround;
    private bool onFloor;
    private LogicScript logic;
    public GameObject winMenu;
    public GameObject gameoverMenu;
    
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playercollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        logic = GameObject.Find("GameManager").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Running", horizontalMove != 0.0f);
        animator.SetBool("Ground", Grounded);
        
        //Input
        horizontalMove = Input.GetAxisRaw("Horizontal");
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
        
        //Falling
        if(Input.GetKeyDown(KeyCode.S)){
            Fall();
        }

        //Crouching
        if(Input.GetKeyDown(KeyCode.S) && onFloor){
            playercollider.size = new Vector2(playercollider.size.x, 0.11f);
            animator.SetBool("Crouch",true);
        }
        if(Input.GetKeyUp(KeyCode.S) && onFloor){
            playercollider.size = new Vector2(playercollider.size.x, 0.22f);
            animator.SetBool("Crouch",false);
        
        }

        if(winMenu.activeInHierarchy == true){
            speed = 0.0f;
        }

        if(gameoverMenu.activeInHierarchy == true){
            Destroy(gameObject);
            speed = 0.0f;
            animator.enabled = false;
        }
        

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy"){
            animator.SetBool("isDead",true);
            logic.Die();
        }

        if(other.gameObject.tag == "Floor"){
            onFloor = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Floor"){
            onFloor = false;
        }
    }

    private void Jump(){
        player.velocity = Vector2.up * jumpForce;
    }
    private void Fall(){
        player.velocity = -Vector2.up * jumpForce;
    }

}
