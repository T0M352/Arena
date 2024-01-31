using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingTxt : MonoBehaviour
{

    void Start()
    {
        GetComponent<Renderer>().sortingOrder = 12;
        GetComponent<Renderer>().sortingLayerName = "Interaktywne";
        Destroy(gameObject, 2);
    }

    public void enterText(string text)
    {
        GetComponent<TextMesh>().text = text;
    }

}
