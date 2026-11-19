using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassarFase : MonoBehaviour
{

    public void Passarfase()//Vareavel publica para passaras fases 
    {
        SceneManager.LoadScene("Fase2");// paadar a fase dois 
    }
}