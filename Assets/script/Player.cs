using UnityEngine;
using UnityEngine.SceneManagement;// Declara a Cena

public class Player : MonoBehaviour
{
    public float speed = 5f; //Variavel publica que determina a velocidade do Player.
    

    private Rigidbody2D rb; // Variavel privada que determina o Rigidbody2D (fisica) do Player.

    private bool isGrounded = false; // Variavel privadada quedetermina assim que o Player pisa no chão, usando um boliano para determinar essa variavem com falsa.

    public MenuScene menu; //Variavrel publica que determina a cena MenuScene como menu.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 

    }

    
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // vai reconhecer o movimento horizontal, ou seja, andar para os lados esquerdo e direto.

        rb.linearVelocity = new Vector2(moveHorizontal * speed, rb.linearVelocity.y); // vai aplicar movimentação de 1,0,-1

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Se a condição  do frame e determina que o Space para pular determinando o chão como verdadeiro.
        { 
          rb.AddForce(new Vector2 (0f,10f),ForceMode2D.Impulse); // vai dar um impulso ao pular, fazendo que o jogador pule e desça com naturalidade. 
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Se a Tag for Ground 
        {
            isGrounded = true; // vai verificar quando ele estiver no chão, se tiver, será cosiderado verdadeiro.
        }

        if (collision.gameObject.CompareTag("Dano")) // Se a tag for Dano.
        {
            menu.MostrarGameOver(); // reconhece/ puxar de um script para outro 
        }

        if (collision.gameObject.CompareTag("PassarFase")) //Se a tag for PassarFase.
        {
            SceneManager.LoadScene("Fase2"); // A cena muda para a proxima fase 
        }
        if (collision.gameObject.CompareTag("VITORIA")) // Determina a tag Vitoria.
        {
            SceneManager.LoadScene("Vitoria"); // exesrce a tag vitoria  
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
