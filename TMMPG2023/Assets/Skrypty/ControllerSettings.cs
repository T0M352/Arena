using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerSettings : MonoBehaviour
{
    public Text txt;
    public int lvlSettings = 0;
    public void onClick()
    {

        if (lvlSettings == 0)
        {
            txt.text = "KLAW. + PAD";
            GameManager.controlSettings = 1;
            lvlSettings = 1;
            
        }
        else if (lvlSettings == 1)
        {
            txt.text = "PAD + PAD";
            GameManager.controlSettings = 2;
            lvlSettings = 2;
            
        }
        else if(lvlSettings == 2)
        {
            txt.text = "KLAWIATURA.";
            GameManager.controlSettings = 0;
            lvlSettings = 0;
            
        }

    }

}
