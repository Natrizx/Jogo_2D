using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public GameObject painelPause; //Variavel publica de painel de Pause
    public GameObject painelGameOver; // Variavel publica painel GameOver
    
    bool pausado = false; // vai retornar falso ao pausar
    bool jogoAcabou = false;  // retorna falso ao acabar o jogo 

    void Start()
    {
      
        painelPause.SetActive(false); // SetActive vai ativar ou desativar determinada função dentro do jogo, nesse caso a tela de pause.
        painelGameOver.SetActive(false); // SetActive vai ativar ou desativar determinada função dentro do jogo , nesse caso o GameOver.
       
    }


    void Update()
    {
        if ( Input.GetKeyUp(KeyCode.Escape) ) // retorna componente de um script anterior 
        {
            if( pausado )//Se a condição acontecer
            {
                Continuar(); // vai continuar 
            }
            else // Senão acontecer 
            {
                Pausar(); // vai pausar
            }
        } 
    }

    public void Pausar() // vou adicionar as condições se ou senão para pausar ou continuar o jogo a partir da tecla espaço.
    {

        if (jogoAcabou==false) //Se o jogo acabar eleretorna falso
        {

            pausado = true; // Paousa e retorna falso
            painelPause.SetActive(true); //Retorna o painel depause como verdadeiro.
            Time.timeScale=0f; // para não deixar o personagem se mover ao mmorrer/pausar o jogo ( nesse caso ao pausar o jgo o jogador não podera se movimentar.

        }
    }
    public void Continuar() // vou adicionar as condições se ou senão para pausar ou continuar o jogo a partir da tecla espaço. 
    {
           
        pausado=false; //pausa e retorna falso
        painelPause.SetActive(false); // retorna o painel de pause  com falso.
        Time.timeScale=1f; //TEMPO - mostra o tempo 

    }
        
    public void MostrarGameOver()
    {
        jogoAcabou =true; // Quando o jogo acabada determina como verdadeiro
        painelGameOver.SetActive(true); // determina o painel de Game over como verdadeiro
        Time .timeScale=0f;// TEMPO- determina o tempo compo 0
    }

    public void Reiniciar()
    {

       Time.timeScale= 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reiniciar a cena

    }
    
    public void VoltarMenu()
    {
        Time .timeScale= 1f; // TEMPO
        SceneManager.LoadScene(0); // retorna a cenaManager
    }

}
