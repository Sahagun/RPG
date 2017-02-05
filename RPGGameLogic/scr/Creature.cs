using System;
using System.Collections.Generic;


public class Creature
{

    public string name { get; set; }

    //    public Dictionary<string, double> baseStats = new Dictionary<string, double>();

    //    public List<Tuple<string, double>> additiveStatsModifiers = new List<Tuple<string, double>>();
    //    public List<Tuple<string, double>> multiplicativeStatsModifiers = new List<Tuple<string, double>>();

    public StatSheet statSheet = new StatSheet();

    public Creature()
    {
        /*

statSheet.AddBaseStat("strength", 0);
statSheet.AddBaseStat("intelligence", 0);
statSheet.AddBaseStat("endurance", 0);
statSheet.AddBaseStat("willpower", 0);
statSheet.AddBaseStat("agility", 0);
*/
    }


    public void PrintBaseStats()
    {
        Console.WriteLine("Base Stats for {0}:", name);
        foreach (KeyValuePair<string, double> pair in statSheet.GetStats())
        {
            Console.WriteLine("{0}\t {1}", pair.Key, pair.Value);
        }
    }

    public void PrintStats()
    {
        Console.WriteLine("Modified Stats for {0}:", name);
        foreach (KeyValuePair<string, double> pair in statSheet.GetStats())
        {
            Console.WriteLine("{0}\t {1}", pair.Key, pair.Value);
        }
    }
}
