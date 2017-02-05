using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGGameLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Creature c = new Creature();

            AddStats(c);
            AddModifier(c);

            c.name = "creature";
            c.printBaseStats();


            Console.WriteLine();

            c.printStats();
            */

            Test te = new Test();

            te.Print();

            te.AddStats();

            te.Print();

            te.AddModifier();

            te.Print();

            te.statSheet.RemoveModifiers("001");
            te.Print();
            te.statSheet.RemoveModifiers("002");
            te.Print();
            te.statSheet.RemoveModifiers("003");

            te.Print();

//            te.statSheet.RemoveAllModifiers();

//            te.print();

            Console.Read();

        }


        class Test : Creature{
            public Test()
            {
                name = "DOGG";

                statSheet.RemoveAllModifiers();

                statSheet.AddBaseStat("strength", 10);
                statSheet.AddBaseStat("intelligence", 10);
                statSheet.AddBaseStat("endurance", 10);
                statSheet.AddBaseStat("willpower", 10);
                statSheet.AddBaseStat("agility", 10);
            }

            public void AddStats()
            {
                statSheet.AddAdditiveStatsModifier("001","strength", 100);
                statSheet.AddAdditiveStatsModifier("002", "agility", 50);
            }

            public void AddModifier()
            {
                statSheet.AddMultiplicativeStatsModifier("001", "strength", 100);
                statSheet.AddMultiplicativeStatsModifier("001", "intelligence", 25);

                statSheet.AddMultiplicativeStatsModifier("002", "agility", .25f);
                statSheet.AddMultiplicativeStatsModifier("002", "intelligence", 0.1f);

                statSheet.AddMultiplicativeStatsModifier("003", "willpower", 35);
                statSheet.AddMultiplicativeStatsModifier("003", "endurance", 100000);
            }

            public void Print()
            {
                PrintBaseStats();
                PrintStats();
            }

        }
    }



}
