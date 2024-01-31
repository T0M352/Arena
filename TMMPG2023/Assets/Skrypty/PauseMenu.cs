using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && GameManager.escMenu == 0)
        {
            GameManager.escMenu = 1;
        }
        else if (Input.GetKeyUp(KeyCode.Escape) && GameManager.escMenu == 1)
        {
            GameManager.escMenu = 0;
        }
    }
}
