using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vitoria: MonoBehaviour
{ 
    public void VoltarMenu()
    {
        Time.timeScale= 1f;
        SceneManager.LoadScene(0);
    }

}