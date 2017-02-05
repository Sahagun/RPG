using System;
using System.Collections.Generic;


public class Creature
{

    public string name { get; set; }

    public Dictionary<string, double> baseStats = new Dictionary<string, double>();

    public List<Tuple<string, double>> additiveStatsModifiers = new List<Tuple<string, double>>();
    public List<Tuple<string, double>> multiplicativeStatsModifiers = new List<Tuple<string, double>>();

    public Creature()
    {
        baseStats.Add("strength", 0);
        baseStats.Add("intelligence", 0);
        baseStats.Add("endurance", 0);
        baseStats.Add("willpower", 0);
        baseStats.Add("agility", 0);
    }

    public double getBaseStat(string statName)
    {
        double statValue = -1;
        baseStats.TryGetValue(statName, out statValue);
        return statValue;
    }

    public bool setBaseStat(string statName, float statValue)
    {
        if (baseStats.ContainsKey(statName))
        {
            baseStats[statName] = statValue;
            return true;
        }
        return false;
    }

    public double getStat(string statName)
    {
        double statValue = -1;
        if (baseStats.TryGetValue(statName, out statValue))
        {
            foreach (Tuple<string, double> t in multiplicativeStatsModifiers)
            {
                if (t.Item1.Equals(statName))
                {
                    statValue *= t.Item2;
                }
            }

            foreach (Tuple<string, double> t in additiveStatsModifiers)
            {
                if (t.Item1.Equals(statName))
                {
                    statValue += t.Item2;
                }
            }
        }
        return statValue;
    }

    public void printBaseStats()
    {
        Console.WriteLine("Base Stats for {0}:", name );
        foreach (KeyValuePair<string, double> pair in baseStats)
        {
            Console.WriteLine("{0}\t {1}", pair.Key, pair.Value);
        }
    }

    public void printStats()
    {
        Console.WriteLine("Modified Stats for {0}:", name);
        foreach (KeyValuePair<string, double> pair in baseStats)
        {
            Console.WriteLine("{0}\t {1}", pair.Key, getStat(pair.Key));
        }
    }


}
