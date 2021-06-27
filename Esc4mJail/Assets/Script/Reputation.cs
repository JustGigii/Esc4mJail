using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reputation : MonoBehaviour
{
    public float maxRep, minRep;

    /// <summary>
    /// list of gangs
    /// go to Reputation file to change gang list
    /// </summary>
    public enum Gangs
    {
        name1 = 0,
        name2 = 1,
        name3 = 2,
        name4 = 3
    }

    private float[] gangsRep;

    /// <summary>
    /// gang += value
    /// </summary>
    /// <param name="gang">use Gangs to get gangs list</param>
    /// <param name="value">amount to add to Reputation</param>
    /// <returns></returns>
    public void AddReputation(int gang, float value)
    {
        gangsRep[gang] += value;
        if (gangsRep[gang] > maxRep)
            gangsRep[gang] = maxRep;
        if (gangsRep[gang] < minRep)
            gangsRep[gang] = minRep;
    }
}
