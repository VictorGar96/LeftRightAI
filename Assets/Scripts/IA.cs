using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IA : MonoBehaviour
{
    public byte windowSize = 2;
    public string totalActions = "";
    public string possibleActions = ""; // Para elegir una de ellas al azar.
    private GamePredictor predictor;
    public static IA instance;
    public float acierto = 0, total = 0;

    public Text fraseText, tablaText;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        predictor = new GamePredictor();
    }

    public void AddAction(char action)
    {
        possibleActions += action;
    }
    private char RandomGuess()
    {
        return possibleActions[Random.Range(0, possibleActions.Length)];
    }

    public void Guess(char correctAnswer)
    {
        string lastActions = "";
        string frase = "";
        total++;
        char guess;
        if (totalActions.Length >= windowSize)
        {
            lastActions = totalActions.Substring(totalActions.Length - windowSize, windowSize);
            guess = predictor.GetMostLikely(lastActions);
            if (guess == ' ')
            {
                guess = RandomGuess();
            }
        }
        else
        {
            guess = RandomGuess();
        }

        if (guess == correctAnswer)
        {
            acierto++;
            frase += "ACIERTO";
        }
        else
        {
            frase += "FALLO";
        }
        frase += " Tasa de aciertos: " + acierto / total + " \n";


        totalActions += correctAnswer;
        frase += totalActions + "\n";
        fraseText.text = frase;

        lastActions = totalActions.Substring(totalActions.Length - windowSize - 1, windowSize + 1);
        predictor.RegisterActions(lastActions);
        tablaText.text = predictor.AString();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
