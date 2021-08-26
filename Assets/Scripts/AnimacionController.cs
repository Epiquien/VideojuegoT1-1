using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionController : MonoBehaviour
{
    public float velocityX = 5;
    public float jumpForce = 30;
    
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;

    private const int Idle = 0;
    private const int Walk = 1;
    private const int Run = 2;
    private const int Jump = 3;
    private const int Attack = 4;

    private bool estaSaltando = false;// Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
     cambiarAnimacion(Idle);
     if (Input.GetKey(KeyCode.RightArrow))
     {
         rb.velocity = new Vector2(velocityX, rb.velocity.y) ;
         sr.flipX = false; 
         cambiarAnimacion(Walk);
     }

     else if (Input.GetKey(KeyCode.LeftArrow))
     {
         rb.velocity = new Vector2(- velocityX, rb.velocity.y);
         sr.flipX = true; 
         cambiarAnimacion(Walk); 
     }
      
     else
     {
         rb.velocity = new Vector2(0, rb.velocity.y);
     }

     if (Input.GetKey(KeyCode.RightArrow  ) && Input.GetKey(KeyCode.X))
     {
         rb.velocity = new Vector2(velocityX + 4, rb.velocity.y) ;
         sr.flipX = false; 
         cambiarAnimacion(Run);
     }
     else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.X))
     {
         rb.velocity = new Vector2(- velocityX - 4, rb.velocity.y);
         sr.flipX = true; 
         cambiarAnimacion(Run);
     }
     
     if(Input.GetKeyUp(KeyCode.Space) && !estaSaltando)
     {
         rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
         cambiarAnimacion(Jump);
         estaSaltando = true;
     }
     
     if(Input.GetKey(KeyCode.Z) )
     {
         
         cambiarAnimacion(Attack);
         
     }
     
     
     


    }

    
    
    private void cambiarAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Suelo")
            estaSaltando = false;
    }
}
