using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string cena;
    [SerializeField]private GameObject painelMenuInicial;
    [SerializeField]private GameObject painelOptions;
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
        UnityEditor.EditorApplication.isPlaying = false;
        // Jogo Compilado
       // Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(cena);

    }
    public void StartOptions()
    {
        painelMenuInicial.SetActive(false);
        painelOptions.SetActive(true);
    }
    public void CloseOptions()
    {
        painelOptions.SetActive(false);
        painelMenuInicial.SetActive(true);
    }

}
