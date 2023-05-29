using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string cena;
    public string cena1;
    [SerializeField]private GameObject painelMenuInicial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void QuitGame()
    {
        // Pelo editor da Unity
        //UnityEditor.EditorApplication.isPlaying = false;
        // Jogo Compilado
       Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(cena);

    }
     public void StartMenu()
    {
        SceneManager.LoadScene(cena1);

    }
}
