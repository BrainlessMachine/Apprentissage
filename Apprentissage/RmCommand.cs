using System;

namespace Apprentissage
{
    public class RmCommand : ICommand
    {
        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Tu dois spécifier le nom du fichier !");
                return;
            }

            string fileName = args[0];
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDirectory, fileName);

            // Vérifie si le fichier existe déjà ou pas
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return;
            }
            else
            {
                Console.WriteLine("Impossible de supprimer le fichier");
                return;
            }
        }
    }
}
