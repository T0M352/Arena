using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrzyciskGraj : MonoBehaviour
{
    public GameObject Menu;
    public GameObject chooseMenu;
    public void onClick()
    {
        Menu.SetActive(false);
        chooseMenu.SetActive(true);
    }
    
    public void onClickExit()
    {
        Application.Quit();
    }

    public void onClickReturnToMenu()
    {
        Menu.SetActive(false);
        SceneManager.LoadScene("Menu");
    }

    public void endGame()
    {
        GameManager.dungeonMode = 0;
        GameManager.PlayerOneLives = 3;
    GameManager.PlayerTwoLives = 3;
    GameManager.respawnPlayerOne = false;
    GameManager.respawnPlayerTwo = false;
        GameManager.ClassP1 = 0;
        GameManager.ClassP2 = 0;
        GameManager.diamondsP1 = 0;
        GameManager.diamondsP2 = 0;
        GameManager.PlayerChoose = 0;
        GameManager.escMenu = 0;
    Menu.SetActive(false);
        SceneManager.LoadScene("Menu");
    }
}
