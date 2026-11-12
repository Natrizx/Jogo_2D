using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManagen : MonoBehaviour
{
 public void StartGame()
 {
     SceneManager.LoadScene("Fase1");
 }

    public void QuitGame()
    {
        Application.Quit();
    }
}
