using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vitoria : MonoBehaviour
{
    public MenuScene menu;
  
    public void Passarfase() // vareavel publica de paasar para fase vitoria 
    {
        SceneManager.LoadScene("Vitoria");// paasar fase vitoria 
    }
}