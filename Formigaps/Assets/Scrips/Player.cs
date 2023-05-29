using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public float Speed;
    private Rigidbody rig;
    private bool isPaused;
    public float JumpForce;
    public bool isJumping;
    public bool doubleJump;
    public bool canMove3D = false;
    public GameObject gameOver;
    public string cena2;
    public string cena3;

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
    void OnTriggerEnter(Collider other){
        if(other.gameObject.layer == 9)
        {
           SceneManager.LoadScene(cena2);
        }
        if(other.gameObject.layer == 10)
        {
            SceneManager.LoadScene(cena3);
        }
        }    
    }

  //  }
    //void OnCollisionExit(Collision collision){
    //     if(collision.gameObject.layer == 6||collision.gameObject.layer == 7 ){
    //        isJumping = true;
         
   //     }
  //  }

    //OnTriggerEnter OnTriggerExit




