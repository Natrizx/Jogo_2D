using UnityEngine;

// Coloque este script no PLAYER (precisa ter Rigidbody2D e BoxCollider2D).
[RequireComponent(typeof(Rigidbody2D))]
public class DashJogador2D : MonoBehaviour
{
    [Header("Configurações do Dash")]
    public KeyCode teclaDash = KeyCode.LeftShift;
    public float velocidadeDash = 20f;   // quão rápido é o dash
    public float duracaoDash = 0.2f;     // quanto tempo dura (segundos)
    public float recargaDash = 1f;       // tempo para usar de novo

    // Seu script de movimento pode checar isso para não atrapalhar o dash
    public bool EstaDandoDash { get; private set; }

    private Rigidbody2D rb;
    private float proximoDashPermitido;
    private float gravidadeOriginal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gravidadeOriginal = rb.gravityScale;
    }

    private void Update()
    {
        if (Input.GetKeyDown(teclaDash) && !EstaDandoDash && Time.time >= proximoDashPermitido)
        {
            StartCoroutine(Dash());
        }
    }

    private System.Collections.IEnumerator Dash()
    {
        EstaDandoDash = true;
        proximoDashPermitido = Time.time + recargaDash;

        // Direção: onde o jogador está apertando.
        // Se estiver parado, vai para o lado que o personagem está olhando.
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 direcao = new Vector2(h, v).normalized;

        if (direcao == Vector2.zero)
            direcao = new Vector2(Mathf.Sign(transform.localScale.x), 0f);

        // Tira a gravidade durante o dash (dash reto, sem cair)
        rb.gravityScale = 0f;
        rb.linearVelocity = direcao * velocidadeDash;

        yield return new WaitForSeconds(duracaoDash);

        rb.linearVelocity = Vector2.zero;
        rb.gravityScale = gravidadeOriginal;
        EstaDandoDash = false;
    }
}
