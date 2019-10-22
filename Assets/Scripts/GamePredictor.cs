using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePredictor
{
    Dictionary<string, DataRecord> data;
    public GamePredictor()
    {
        data = new Dictionary<string, DataRecord>();
    }
    public void RegisterActions (string actions)
    {
        string key = actions.Substring(0, actions.Length - 1);
        char value = actions[actions.Length - 1];

        if (!data.ContainsKey(key))
        {
            data[key] = new DataRecord();
        }
        DataRecord record = data[key];
        if (!record.counts.ContainsKey(value))
        {
            record.counts[value] = 0;
        }
        record.counts[value]++;
        record.total++;
    }

    public char GetMostLikely(string actions)
    {
        char bestAction = ' ';
        int highestValue = 0;
        DataRecord record;
        if (data.ContainsKey(actions))
        {
            record = data[actions];
            foreach(char action in record.counts.Keys)
            {
                if(record.counts[action] > highestValue)
                {
                    bestAction = action;
                    highestValue = record.counts[action];
                }
                else if (record.counts[action] == highestValue)
                {
                    if(Random.value <= 0.5f)
                    {
                        bestAction = action;
                        highestValue = record.counts[action];
                    }
                }
            }
        }

        return bestAction;
    }

    public string AString()
    {
        string respuesta = "";
        foreach(string key in data.Keys)
        {
            respuesta += "\n" + key + ": ";
            DataRecord record = data[key];
            foreach (char action in record.counts.Keys)
            {
                respuesta += "  " + action + "->" + record.counts[action];
            }
        }
        return respuesta;
    }
}
