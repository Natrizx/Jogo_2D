using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform alvo; //Variavel publica para transformar/determinar o alvo da camera.
    public Vector3 distancia = new Vector3(0f, 0f, -10f);// Variavel que determinal a distancia no eixo Z.
    public bool movimentoSuave = true;// Variavel boliana (verdadeiro ou falso) qu determina o movimentoSuave.
    public float velocidade = 5f;// Vareavel publica que determina a velocidade da camera. 

    void LateUpdate()
    {
        Vector3 posicaoDesejada = alvo.position + distancia; // Fara com que acamera foque diretamente no alvo (Player).

        if (movimentoSuave) // Se a condição (movimentoSuave) for verdadeira.
        {
            transform.position = Vector3.Lerp(transform.position, posicaoDesejada, velocidade * Time.deltaTime); //se for verdadeiro ele vai mudar o transform da camera deixando a transição entre osfremes mais suave.
        }
        else //Senão
        {
            transform.position= posicaoDesejada; // so pega a transição eaplica no transforme 
        }
    }
}
