using System;
using System.IO;
using System.Linq;

namespace Apprentissage
{
    public class LsCommand : ICommand
    {
        public void Execute(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            bool longListing = false;

            /// Analyse des arguments
            foreach (var arg in args)
            {
                /// C'est pour éviter l'erreur du string[] et string
                if (arg == "-l")
                    longListing = true;
                else
                    path = Path.Combine(path, arg);
            }

            if (!Directory.Exists(path))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Le répertoire '{path}' n'existe pas.");
                Console.ResetColor();
                return;
            }

            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);

            foreach (var dir in directories)
            {
                var dirInfo = new DirectoryInfo(dir);
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (longListing)
                {
                    Console.WriteLine($"    {dirInfo.Name}    - {dirInfo.CreationTime,-20}");
                }
                else
                {
                    Console.WriteLine("    " + dirInfo.Name);
                }
            }

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                Console.ForegroundColor = ConsoleColor.Gray;
                if (longListing)
                {
                    Console.WriteLine($"    {fileInfo.Name}    - {fileInfo.Length,8} {fileInfo.CreationTime,-20}");
                }
                else
                {
                    Console.WriteLine("    " + fileInfo.Name);
                }
            }

            Console.ResetColor();
            return;
        }
    }
}
