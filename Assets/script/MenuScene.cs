using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public GameObject painelPause;
    public GameObject painelGameOver;
    
    bool pausado = false; // vai retornar falso ao pausar
    bool jogoAcabou = false; 

    void Start()
    {
      
        painelPause.SetActive(false); // SetActive vai ativar ou desativar determinada função dentro do jogo, nesse caso a tela de pause.
        painelGameOver.SetActive(false); // SetActive vai ativar ou desativar determinada função dentro do jogo , nesse caso o GameOver.

    }


    void Update()
    {
        if ( Input.GetKeyUp(KeyCode.Escape) )
        {
            if( pausado )
            {
                Continuar(); 
            }
            else
            {
                Pausar();
            }
        } 
    }

    public void Pausar() // vou adicionar as condições se ou senão para pausar ou continuar o jogo a partir da tecla espaço.
    {

        if (jogoAcabou==false)
        {

            pausado = true;
            painelPause.SetActive(true);
            Time.timeScale=0f; // para não deixar o personagem se mover ao mmorrer/pausar o jogo ( nesse caso ao pausar o jgo o jogador não podera se movimentar.

        }
    }
    public void Continuar() // vou adicionar as condições se ou senão para pausar ou continuar o jogo a partir da tecla espaço. 
    {
           
        pausado=false;
        painelPause.SetActive(false);
        Time.timeScale=1f;

    }
        
    public void MostrarGameOver()
    {
        jogoAcabou =true;
        painelGameOver.SetActive(true);
        Time .timeScale=1f;
    }

    public void Reiniciar()
    {

       Time.timeScale= 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reiniciar a cena

    }
    
    public void VoltarMenu()
    {
        Time .timeScale= 1f;
        SceneManager.LoadScene(0);
    }

}
