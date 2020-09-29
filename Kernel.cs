using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.Threading;
using System.IO;
using Cmds = FD_DOS.cmds;

namespace FD_DOS
{
    public class Kernel : Sys.Kernel
    {
        public static string version = "Alpha 0.0.1";
        public string lang;
        public bool runned;
        protected override void BeforeRun()
        {
            Cosmos.Core.ACPI.Enable();
            runned = false;
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
                Cosmos.HAL.Global.PIT.Wait(750);
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
        public void CmdToRun()
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
        public void RunPL()
        {
            switch (runned)
            {
                case true:
                    break;

                case false:
                    Console.Clear();
                    Console.WriteLine("FD-DOS uruchomiony pomyslnie.");
                    runned = true;
                    break;
            }
            Console.Write("Komenda: ");
            var input = Console.ReadLine();
            cmds.CheckForCMD(input, lang);
            // Cosmos.HAL.Global.PIT.Wait(250);
            RunPL();
        }
        public void RunEN()
        {
            switch (runned)
            {
                case true:
                    break;

                case false:
                    Console.Clear();
                    Console.WriteLine("FD-DOS booted successfully.");
                    runned = true;
                    break;
            }
            Console.Write("Command: ");
            var input = Console.ReadLine();
            cmds.CheckForCMD(input, lang);
            // Cosmos.HAL.Global.PIT.Wait(250);
            RunEN();
        }
    }
}
