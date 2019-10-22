using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataRecord
{
    public int total;
    public Dictionary<char, int> counts;
    public DataRecord()
    {
        total = 0;
        counts = new Dictionary<char, int>();
    }
}
