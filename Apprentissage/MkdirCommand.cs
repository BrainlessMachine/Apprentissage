using System.IO;

namespace Apprentissage
{
    public class MkdirCommand : ICommand
    {
        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Tu dois spécifier le nom du dossier !");
                return;
            }

            string dirName = args[0];
            string currentDirectory = Directory.GetCurrentDirectory();
            string dirPath = Path.Combine(currentDirectory, dirName);

            // Vérifie si le fichier existe déjà
            if (!Directory.Exists(dirPath))
            {
                // Crée le fichier
                Directory.CreateDirectory(dirPath);
            }
            else
            {
                Console.WriteLine("Impossible de créer le dossier");
            }
        }
    }
}
