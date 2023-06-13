using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
   [SerializeField] private AudioSource clickSound;
    public void StartGame()
    {
        print("startgame");
        clickSound.Play();
        Invoke("Game", 1f);
    }
    private void Game()
    {
        print("game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
