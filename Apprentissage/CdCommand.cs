using System;
using System.IO;

namespace Apprentissage
{
    public class CdCommand : ICommand
    {
        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                ///Si t'as pas mis le répertoire où tu veux aller
                Console.WriteLine("Tu dois spécifier un répertoire !");
                return;
            }

            string newDirectory = args[0];

            /// Vérifie si le répertoire existe
            if (Directory.Exists(newDirectory))
            {
                /// Si il existe alors pouf, active directory
                Directory.SetCurrentDirectory(newDirectory);
            }
            else
            {
                /// C'est mieux, ça évite les \n
                Console.WriteLine($"Le répertoire {newDirectory} n'existe pas.");
            }
        }
    }
}
