using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Apprentissage
{
    public class MvCommand : ICommand
    {
        public void Execute(string[] args)
        {
            /// Si tout les arguments ne sont pas présents
            if (args.Length < 2)
            {
                Console.WriteLine("Tu dois spécifier la source et la destination !");
                return;
            }

            /// Le chemin complet vers le fichier source
            string fileName = args[0];

            /// La destionation
            string destPath = args[1];

            /// Le dossier actuel
            string currentDirectory = Directory.GetCurrentDirectory();

            /// Je ne comprends pas tout tout mais tkt
            string filePath = Path.Combine(currentDirectory, fileName);

            /// Ne récup que le nom du fichier parmis le chemin absolu
            string fileOnlyName = Path.GetFileName(filePath);

            /// Sert à résoudre le chemin absolu pour la destination (au cas où ce serait un chemin relatif classique)
            if (destPath == "./" || destPath == ".")
            {
                /// Là tu combine le nom du fichier extrait et le chemin absolu déduit du relatif
                destPath = Path.Combine(currentDirectory, fileOnlyName);
            }
            else if (destPath.StartsWith("/"))
            {
                destPath = Path.Combine(currentDirectory, destPath.TrimStart('/'));
            }

            /// Vérifie si le fichier source existe sinon ça copie du rien à destination de rien, donc ça fait rien mais c'est mieux de vérifier
            if (File.Exists(filePath))
            {
                /// Si le dest est un dossier
                if (Directory.Exists(destPath))
                {
                    string finalDest = Path.Combine(destPath, fileOnlyName);
                    File.Move(filePath, finalDest, true);
                    return;
                }
                else
                {
                    File.Move(filePath, destPath, true);
                    return;
                }
            }
            else
            {
                Console.WriteLine("Impossible de trouver le fichier source.");
            }
        }
    }
}
