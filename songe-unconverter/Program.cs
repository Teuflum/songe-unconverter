using Newtonsoft.Json;
using songe_unconverter.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace songe_unconverter
{
    class Program
    {
        private static readonly UTF8Encoding UTF8 = new UTF8Encoding(false);

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            if (args.Length < 1)
            {
                HandleError($"Need at least one folder as parameter to convert songes from!");
            }
            else
            {
                int failCounter = 0;
                foreach (var arg in args)
                {
                    if (!Directory.Exists(arg))
                        Console.WriteLine($"Couldn't find directory '{arg}'!");
                    else
                    {
                        if (File.Exists(Path.Combine(arg, "info.dat")))
                        {
                            try
                            {
                                ConvertFolder(arg);
                            }
                            catch(Exception ex)
                            {
                                failCounter++;
                                var oldColor = Console.ForegroundColor;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{ex.Message}\n{ex.StackTrace}");
                                Console.ForegroundColor = oldColor;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Couldn't find info.dat in '{arg}'!");
                        }
                    }
                }
                if(failCounter > 0)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Couldn't convert {failCounter} {(failCounter == 1 ? "songe!" : "songes!")}\nPress any key to exit...");
                    Console.ReadKey();
                }
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Exception ex = e.ExceptionObject as Exception;
            Console.WriteLine($"{ex.Message}\n{ex.StackTrace}\nPress any key to continue...");
            Console.ForegroundColor = oldColor;
            Console.ReadKey();
        }

        static void ConvertFolder(string folderPath)
        {
            string infoFilePath = Path.Combine(folderPath, "info.dat");
            if (!File.Exists(infoFilePath))
                Console.WriteLine($"Couldn't find info.dat in '{folderPath}'!");
            else
            {
                Console.WriteLine($"Converting '{folderPath}'");
                string infoContent = File.ReadAllText(infoFilePath, UTF8);
                InfoDat infoDat = JsonConvert.DeserializeObject<InfoDat>(infoContent);
                var convJsons = Converter.ConvertInfo(infoDat, folderPath);

                File.WriteAllText(Path.ChangeExtension(infoFilePath, "json"),
                    JsonConvert.SerializeObject(convJsons.Item1, Formatting.Indented));
                File.Delete(infoFilePath);
                foreach (var diffJson in convJsons.Item2)
                {
                    File.WriteAllText(Path.Combine(folderPath, diffJson.FileName),
                        JsonConvert.SerializeObject(diffJson));
                    File.Delete(Path.Combine(folderPath, diffJson.FileName.Replace(".json", ".dat")));
                }

                if (infoDat._songFilename.Contains(".egg"))
                {
                    File.Copy(Path.Combine(folderPath, infoDat._songFilename), Path.Combine(folderPath, infoDat._songFilename.Replace(".egg", ".ogg")), true);
                    File.Delete(Path.Combine(folderPath, infoDat._songFilename));
                }
            }
        }

        static void HandleError(string errorMessage)
        {
            Console.WriteLine($"{errorMessage}\nPress any key to continue...");
            Console.ReadKey();
            Environment.Exit(1);
        }
    }
}
