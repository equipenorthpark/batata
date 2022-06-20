using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batata : MonoBehaviour
{
    // Variavel para contolar a velocidade do personagem.
    public float Speed;
    public float JumpForce;

    // Para controlar o Pulo e o Pulo duplo.
    public bool isJumping;
    public bool doubleJump;
    
    private Rigidbody2D rig;
    private Animator anim;

    // Chamado uma vez quando inicializa o jogo.
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Chamado a cada frame.
    void Update()
    {
        Move();
        Jump();
    }

    void Move() 
    {
        // Faz com que o personagem se movimente.
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += movement * Time. deltaTime * Speed;

        if(Input.GetAxis("Horizontal") > 0f) 
        {
            anim.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
        if(Input.GetAxis("Horizontal") < 0f) 
        {
            anim.SetBool("Run", true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
        if(Input.GetAxis("Horizontal") == 0f) 
        {
            anim.SetBool("Run", false);
        }
    }

    void Jump() 
    {
        // Faz com que o personagem pule
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if( doubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.layer == 8) 
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }
    }
    
    void OnCollisionExit2D(Collision2D collision) 
    {
        if(collision.gameObject.layer == 8) 
        {
            isJumping = true;
        }
    }
}
