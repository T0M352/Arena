using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dungeonButton : MonoBehaviour
{
    public Text onof;
    public bool trunedOn = true;
    public void onClick()
    {
        
        if (trunedOn == true)
        {
            onof.text = "NIEAKTYWNE";
            GameManager.dungeonMode = -1;
            trunedOn = false;
        }else
        {
            onof.text = "AKTYWNE";
            GameManager.dungeonMode = 0;
            trunedOn = true;
        }

    }

    private void Update()
    {
        Debug.Log(GameManager.dungeonMode);
    }
}
