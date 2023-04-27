using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tamagochi
{
    internal class Global
    {
        enum Activities
        {
            play=0,eat,sleep,walk,treat
        }
        class Tamagochi
        {
            public void menu()
            {
                Console.WriteLine("Choose option:");
                Console.WriteLine("0 - play");
                Console.WriteLine("1 - eat");
                Console.WriteLine("2 - sleep");
                Console.WriteLine("3 - walk");
                Console.WriteLine("4 - treat");
            }
            bool correct=false;
            Random rand = new Random();
            int health=3;
            System.Timers.Timer timer = new System.Timers.Timer();
            public Tamagochi()
            {
                correct = true;
                timer.Interval = 13000;
                timer.Elapsed += play;
                timer.Start();
            }
            public void play(Object source, System.Timers.ElapsedEventArgs e)
            {
                if (correct == false)
                {
                    health--;
                    Console.WriteLine("you didn't make it in time(");

                }
                correct = false;
                if (health == -1)
                {
                    timer.Stop();
                    Console.WriteLine("Tamagochi is dead((");
                    throw new Exception("Dead");
                }
                Thread.Sleep(1000);
                Console.Clear();
                this.p_character();
                this.ask();


                    
            }
            public void p_character() {
                Console.OutputEncoding = Encoding.Unicode;
                if (health == -1)
                {
                    Console.WriteLine("Tamagochi is dead((");
                    throw new Exception("Dead");
                }
                Console.WriteLine("     ■■■■■■");
                Console.WriteLine("    ■     ■");
                Console.WriteLine("   ■  ■■■■■■");
                Console.WriteLine("  ■ ■■     ■");
                Console.WriteLine(" ■     ■■■  ■■");
                Console.WriteLine(" ■ ■  ■■■■■■  ■");
                Console.WriteLine(" ■          ■ ■");
                Console.WriteLine(" ■■          ■");
                Console.WriteLine("  ■■■  ■ ■■  ■");
                Console.WriteLine("  ■   ■■■   ■");
                Console.WriteLine("  ■■■■  ■■■■");
                Console.WriteLine();
                Console.Write("     ");

                if (health == 0) {
                    Console.Write("\bsick");
                    Console.WriteLine();
                    Console.WriteLine();
                    return;
                        }

                for (int i = 0; i < this.health; i++) { Console.Write("\u2665"); }
                Console.WriteLine();
                Console.WriteLine();
                Console.OutputEncoding = Encoding.Default;
            }
            public void ask()
            {
                if (health == 0)
                {
                    Console.WriteLine("Tamagochi NEED to treat");
                    this.menu();
                    Activities buf = (Activities)Convert.ToInt32(Console.ReadLine());
                    if (buf == Activities.treat)
                    {
                        health++;
                        correct = true;
                    }
                    if (buf != Activities.treat)
                    {
                        timer.Stop();
                        Console.WriteLine("Tamagochi is dead((");
                        throw new Exception("Dead");
                    }


                }

                Activities want = (Activities)rand.Next(5); // 0 - 4
                Console.WriteLine($"Tamagochi wants to {want.ToString()}");
                this.menu();
                Activities choice = (Activities)Convert.ToInt32(Console.ReadLine());
                if (choice == want) {
                    correct = true;
                    Console.WriteLine("Tamagochi is so happy!");
                    while (true) { }
                }
                if (choice != want)
                {
                    health--;
                    Console.WriteLine("Tamagochi dont want to do this!");
                    correct = true;
                }
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Tamagochi tm = new Tamagochi();
                System.Timers.ElapsedEventArgs e = null;
                tm.play(null,e);
                while (true) { }
            }
            catch (Exception)
            {
            }
            Console.WriteLine("Thanks for playing!");
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
