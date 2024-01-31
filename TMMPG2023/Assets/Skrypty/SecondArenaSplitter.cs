using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondArenaSplitter : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.dungeonMode == 3)
            gameObject.SetActive(false);
    }
}
