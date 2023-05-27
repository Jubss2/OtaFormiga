using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    private Rigidbody rig;
    public float JumpForce;
    public bool isJumping;
    public bool doubleJump;
    public bool canMove3D = false;
    public GameObject gameOver;

    private Animator anim;

    public LayerMask isGround;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if(Input.GetAxis("Horizontal") > 0f )
        {
        anim.SetBool("walk", true);
        transform.eulerAngles = new Vector3 (0f,0f,0f);
        }    
        if(Input.GetAxis("Horizontal") < 0f )
        {
        anim.SetBool("walk", true);
        transform.eulerAngles = new Vector3 (0f,180f,0f);
        }    
        if(Input.GetAxis("Horizontal") == 0f )
        {
        anim.SetBool("walk", false);
        }    

    }

    void Jump() {
        if(Input.GetButtonDown("Jump") && !isJumping){
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode.Impulse);
            //pulo duplo ou um só?
            anim.SetBool("jump", true);
            isJumping = true;

        }
       
    }

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.layer == 6 ||collision.gameObject.layer == 7 ){
            isJumping = false;
            anim.SetBool("jump", false);
           
    }
    }
    void OnCollisionExit(Collision collision){
         if(collision.gameObject.layer == 6||collision.gameObject.layer == 7 ){
            isJumping = true;
         
        }
    }

    //OnTriggerEnter OnTriggerExit

}


