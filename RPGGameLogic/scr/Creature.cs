using System;
using System.Collections.Generic;


namespace RPGGameLogic
{

    public class Creature
    {

        public string name { get; set; }

        public StatSheet statSheet = new StatSheet();
        public EquipmentSystem equipment = new EquipmentSystem();
        public Restriction restriction = new Restriction();

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
}