using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vitoria : MonoBehaviour
{
    public MenuScene menu;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Passarfase()
    {
        SceneManager.LoadScene("Vitoria");
    }
}