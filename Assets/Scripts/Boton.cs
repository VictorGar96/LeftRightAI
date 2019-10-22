using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boton : MonoBehaviour
{
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        IA.instance.AddAction(text.text[0]);
    }
    public void PulsarBoton()
    {
        IA.instance.Guess(text.text[0]);
    }
 
}
