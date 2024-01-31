using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splitScreen : MonoBehaviour
{

    private void Update()
    {
        if(GameManager.dungeonMode == 2)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}
