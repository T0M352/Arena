using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text Player;



    public void ChooseKnight1()
    {
        
        if(GameManager.PlayerChoose == 0)
        {
            
            Player.text = "Gracz 2 wybiera";
            GameManager.ClassP1 = 1;
            GameManager.PlayerChoose = 1;

        }
        else if(GameManager.PlayerChoose == 1)
        {

            GameManager.ClassP2 = 1;
            SceneManager.LoadScene("Main");
        }
    }
    public void ChooseBarb1()
    {   
        if(GameManager.PlayerChoose == 0)
        {
            Player.text = "Gracz 2 wybiera";

            GameManager.ClassP1 = 2;
            GameManager.PlayerChoose = 1;
        }
        else if(GameManager.PlayerChoose == 1)
        {

            GameManager.ClassP2 = 2;
            SceneManager.LoadScene("Main");
        }
    }

    public void ChooseThief1()
    {
        if (GameManager.PlayerChoose == 0)
        {
            Player.text = "Gracz 2 wybiera";

            GameManager.ClassP1 = 3;
            GameManager.PlayerChoose = 1;
        }
        else if (GameManager.PlayerChoose == 1)
        {

            GameManager.ClassP2 = 3;
            SceneManager.LoadScene("Main");
        }
    }

    public void ChooseMagef1()
    {
        if (GameManager.PlayerChoose == 0)
        {
            Player.text = "Gracz 2 wybiera";

            GameManager.ClassP1 = 4;
            GameManager.PlayerChoose = 1;
        }
        else if (GameManager.PlayerChoose == 1)
        {

            GameManager.ClassP2 = 4;
            SceneManager.LoadScene("Main");
        }
    }

}
