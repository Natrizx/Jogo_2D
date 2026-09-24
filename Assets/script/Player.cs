using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    

    private Rigidbody2D rb;

    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // vai reconhecer o movimento horizontal

        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y); // vai aplicar movimento de 1,0,-1

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        { 
          rb.AddForce(new Vector2 (0f,10f),ForceMode2D.Impulse); // vai dar um impulço ao pulo para q ele pule e desça com naturalidade. 
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // vai verificar quando ele vai ser verdadeiro
        }  
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // vai reconhecer quando o player não estiver mais no chão ou seja um Game Object ( plataforma ), para que ele não pule infinitamente.  
        }
    }

}
