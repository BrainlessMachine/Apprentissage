using System;

namespace Apprentissage
{
    public class RmdirCommand : ICommand
    {
        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Tu dois spécifier le nom du dossier !");
                return;
            }

            string DirectoryName = args[0];
            string currentDirectory = Directory.GetCurrentDirectory();
            string DirectoryPath = Path.Combine(currentDirectory, DirectoryName);

            // Vérifie si le dossier existe déjà ou pas
            if (Directory.Exists(DirectoryPath))
            {
                Directory.Delete(DirectoryPath);
                return;
            }
            else
            {
                Console.WriteLine("Impossible de supprimer le dossier");
                return;
            }
        }
    }
}
