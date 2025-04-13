using System.IO;

namespace Apprentissage
{
    public class MkdirCommand : ICommand
    {
        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Tu dois sp�cifier le nom du dossier !");
                return;
            }

            string dirName = args[0];
            string currentDirectory = Directory.GetCurrentDirectory();
            string dirPath = Path.Combine(currentDirectory, dirName);

            // V�rifie si le fichier existe d�j�
            if (!Directory.Exists(dirPath))
            {
                // Cr�e le fichier
                Directory.CreateDirectory(dirPath);
            }
            else
            {
                Console.WriteLine("Impossible de cr�er le dossier");
            }
        }
    }
}
