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
//            TupleTest();
//            AnonTypeTest();
//            StructTest();
            ListRemoveTest01();
            Console.Read();
        }

        public static void ListRemoveTest01()
        {
            List<string> list = new List<string>();
            list.Add("Dog");
            list.Add("Dog");
            list.Add("Cat");
            list.Add("Dog");
            Console.WriteLine(list.Count);
            list.RemoveAll(x => x.Equals("Dogg"));
            Console.WriteLine(list.Count);
        }

        public static void TupleTest()
        {
            Tuple<string, int> x1 = new Tuple<string, int>("test1", 6);
            Tuple<string, int> x2 = new Tuple<string, int>("test1", 6);

            Console.WriteLine("Tuple Test");

            Console.WriteLine(x1 == x2);
            Console.WriteLine(x1.Equals(x2));
            Console.WriteLine(x1.GetHashCode());
            Console.WriteLine(x2.GetHashCode());
        }

        public static void AnonTypeTest()
        {
            var x1 = new
            {
                t = "taco",
                d = 5
            };
            var x2 = new
            {
                t = "taco",
                d = 5
            };

            Console.WriteLine("Anonymous types  Test");
            Console.WriteLine(x1 == x2);
            Console.WriteLine(x1.Equals(x2));
            Console.WriteLine(x1.GetHashCode());
            Console.WriteLine(x2.GetHashCode());
        }

        public static void StructTest()
        {
            TestStruct x1 = new TestStruct("cat", 9);
            TestStruct x2 = new TestStruct("cat", 9);

            //Console.WriteLine(x1 == x2);
            Console.WriteLine("Stuct Test");
            Console.WriteLine(x1.Equals(x2));
            Console.WriteLine(x1.GetHashCode());
            Console.WriteLine(x2.GetHashCode());
        }

        struct TestStruct{
            string A { get; set; }
            int B { get; set; }

            public TestStruct(string a, int b)
            {
                A = a;
                B = b;
            }
        }

        class Test : Creature{

            public static void TestMain()
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
