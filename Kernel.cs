using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.Threading;

namespace FD_DOS
{
    public class Kernel : Sys.Kernel
    {
        string lang;
        public static void WaitSeconds(int secNum)
        {
            int StartSec = RTC.Second;
            int EndSec;
            if (StartSec + secNum > 59)
            {
                EndSec = 0;
            }
            else
            {
                EndSec = StartSec + secNum;
            }
            while (RTC.Second != EndSec)
            {
                // Loop round
            }
        }
        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("Polski (P) / English (E)?");
            Console.Write("Jezyk / Language: ");
            char langChar = Console.ReadKey().KeyChar;
            if (langChar == 'p' || langChar == 'P')
            {
                lang = "PL";
            }
            else if (langChar == 'e' || langChar == 'E')
            {
                lang = "EN";
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Incorrect selection / Niepoprawny wybor");
                Console.WriteLine("Try again / Sprobuj ponownie");
                System.Threading.Thread.Sleep(250);
                Console.Clear();
                BeforeRun();
            }
        }

        protected override void Run()
        {
            Console.Clear();
            if (lang == "PL")
            {
                RunPL();
            }
            if (lang == "EN")
            {
                RunEN();
            }
            else
            {
                BeforeRun();
            }
        }
        protected void RunPL()
        {
            Console.Clear();
            Console.WriteLine("FD-DOS uruchomiony pomyslnie.");
            Console.Write("Input: ");
            var input = Console.ReadLine();
            Console.Write("Text typed: ");
            Console.WriteLine(input);
            System.Threading.Thread.Sleep(250);
            RunPL();
        }
        protected void RunEN()
        {
            Console.Clear();
            Console.WriteLine("FD-DOS booted successfully.");
            Console.Write("Input: ");
            var input = Console.ReadLine();
            Console.Write("Text typed: ");
            Console.WriteLine(input);
            System.Threading.Thread.Sleep(250);
            RunEN();
        }
    }
}
