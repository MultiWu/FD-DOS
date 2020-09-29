using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using Kernel = FD_DOS.Kernel;

namespace FD_DOS
{
    public class cmds
{
        public static void CheckForCMD(string input, string lang)
        {
            switch (input)
            {
                case "about":
                    Console.WriteLine("|------------------------------------|");
                    Console.WriteLine("|               FD-DOS               |");
                    Console.WriteLine("| Copyright (c) 2019, COSMOS Project |");
                    Console.WriteLine("|    Copyright (c) 2020, MultiWu     |");
                    Console.WriteLine("|------------------------------------|");
                    if (lang == "PL")
                    {
                        Console.WriteLine("Kliknij jakikolwiek klawisz aby kontynuowac...");
                    }
                    else if (lang == "EN")
                    {
                        Console.WriteLine("Click any key to continue...");
                    }
                    Console.ReadKey();
                    break;
                case "help":
                    switch (lang)
                    {
                        case "PL":
                            Console.WriteLine("|-------------KOMENDY-----------|");
                            Console.WriteLine("|-----1.help - Lista komend.----|");
                            Console.WriteLine("|-----2.about - O systemie.-----|");
                            Console.WriteLine("|---3.cls - Czyszczenie ekranu--|");
                            Console.WriteLine("|--4.exit - Wylaczenie komputera|");
                            Console.WriteLine("|---5.version - Wersja systemu--|");
                            Console.WriteLine("|-------------------------------|");
                            Console.WriteLine("Kliknij jakikolwiek klawisz aby kontynuowac...");
                            break;

                        case "EN":
                            Console.WriteLine("|-------------COMMANDS-------------|");
                            Console.WriteLine("|----1.help - List of commands.----|");
                            Console.WriteLine("|----2.about - About a OS.---------|");
                            Console.WriteLine("|----3.cls - Clean screen.---------|");
                            Console.WriteLine("|----4.exit - Shutdown.------------|");
                            Console.WriteLine("|----5.version - OS Version--------|");
                            Console.WriteLine("|----------------------------------|");
                            Console.WriteLine("Click any key to continue...");
                            break;
                    }
                    Console.ReadKey();
                    break;

                case "cls":
                    Console.Clear();
                    break;

                case "exit":
                    Cosmos.Core.ACPI.Shutdown();
                    break;

                case "version":
                    switch (lang)
                    {
                        case "PL":
                            Console.Write("Wersja systemu: ");
                            break;

                        case "EN":
                            Console.Write("OS Version: ");
                            break;
                    }
                    Console.Write(Kernel.version);
                    Console.WriteLine("");
                    break;

                default:
                    switch (lang)
                    {
                        case "PL":
                            Console.WriteLine("Nieprawidlowa komenda!");
                            Cosmos.HAL.Global.PIT.Wait(1000);
                            break;

                        case "EN":
                            Console.WriteLine("Invalid command!");
                            Cosmos.HAL.Global.PIT.Wait(1000);
                            break;
                    }
                    break;
            }
            return;
        }
}
}
