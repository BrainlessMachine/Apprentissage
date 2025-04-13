using System;
using System.Net.NetworkInformation;

namespace Apprentissage
{
    public class CpCommand : ICommand
    {
        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Tu dois spécifier la destination !");
                return;
            }

            string fileName = args[0];
            string destPath = args[1];
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDirectory, fileName);

            // Vérifie si le fichier existe déjà ou pas
            if (File.Exists(filePath))
            {
                if (Directory.Exists(destPath))
                {
                    string finalDest = Path.Combine(destPath, fileName);
                    File.Copy(filePath, finalDest, true);
                    return;
                }
                else
                {
                    try
                    {
                        File.Copy(filePath, destPath, true); // Copie directe, si c'est un fichier complet
                        return;
                    }
                    catch
                    {
                        Console.WriteLine("La destination n'est pas valide.");
                        return;
                    }
                }
            }
            else
            {
                Console.WriteLine("Impossible de copier le fichier");
            }
        }
    }
}
