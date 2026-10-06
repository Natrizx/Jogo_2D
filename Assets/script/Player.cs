using UnityEngine;
using UnityEngine.SceneManagement;

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
        float moveHorizontal = Input.GetAxis("Horizontal"); // vai reconhecer o movimento horizontal, ou seja, andar para os lados esquerdo e direto.

        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y); // vai aplicar movimentação de 1,0,-1

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        { 
          rb.AddForce(new Vector2 (0f,10f),ForceMode2D.Impulse); // vai dar um impulso ao pular, fazendo que o jogador pule e desça com naturalidade. 
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // vai verificar quando ele estiver no chão, se tiver, será cosiderado verdadeiro.
        }
        

        if (collision.gameObject.CompareTag("Dano"))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // vai reconhecer quando o player não estiver mais no chão ou seja em um  Game Object ( plataforma ), para que ele não pule infinitamente.  
        }
    }

}
