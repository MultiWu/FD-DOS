using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.Threading;
using System.IO;
using Cmds = FD_DOS.Cmds;
using Cosmos.HAL;
using Cosmos.System.Graphics;
using System.Runtime.InteropServices.ComTypes;

namespace FD_DOS
{
    public class Kernel : Sys.Kernel
    {
        public static string version = "Alpha 0.0.2";
        public string lang;
        public bool runned;
        Canvas canvas;
        protected override void BeforeRun()
        {
            try
            {
                var tryb = new Mode(800, 600, ColorDepth.ColorDepth32);
                VGAScreen.SetTextMode(VGADriver.TextSize.Size90x60);
                // canvas = FullScreenCanvas.GetFullScreenCanvas(tryb);
                // canvas.Mode = new Mode(800, 600, ColorDepth.ColorDepth32);
                // canvas.Clear();
                // canvas.Disable();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Resolution Setting crashed..");
                Console.WriteLine("FD-DOS doesn't support your PC or VM");
                Cosmos.HAL.Global.PIT.Wait(1250);
                Cosmos.Core.ACPI.Shutdown();
            }
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect selection / Niepoprawny wybor");
                Console.WriteLine("Try again / Sprobuj ponownie");
                Console.ForegroundColor = ConsoleColor.White;
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
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("FD-DOS uruchomiony pomyslnie.");
                    Console.ForegroundColor = ConsoleColor.White;
                    runned = true;
                    break;
            }
            Console.Write("Komenda: ");
            var input = Console.ReadLine();
            Cmds.CheckForCMD(input, lang);
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
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("FD-DOS booted successfully.");
                    Console.ForegroundColor = ConsoleColor.White;
                    runned = true;
                    break;
            }
            Console.Write("Command: ");
            var input = Console.ReadLine();
            Cmds.CheckForCMD(input, lang);
            // Cosmos.HAL.Global.PIT.Wait(250);
            RunEN();
        }
    }
}
