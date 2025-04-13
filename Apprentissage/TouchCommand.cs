using System.IO;

namespace Apprentissage
{
    public class TouchCommand : ICommand
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

            // Vérifie si le fichier existe déjà
            if (!File.Exists(filePath))
            {
                // Crée le fichier
                using (FileStream fs = File.Create(filePath))
                {
                    // Le fichier est créé, le flux est automatiquement fermé ici grâce à 'using'
                }
            }
            else
            {
                Console.WriteLine("Impossible de créer le fichier");
            }
        }
    }
}
