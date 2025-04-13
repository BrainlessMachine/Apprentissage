using System;
using System.Diagnostics;
using System.Security.Principal;

namespace Apprentissage
{
    public class SudoCommand : ICommand
    {
        /// Vérifie si le logiciel est lancé en administrateur
        private static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Veillez à mettre les arguments nécessaire");
                return;
            }

            string action = args[0];

            if (action == "su" && !IsAdministrator())
            {
                Console.WriteLine("Élévation en cours...");

                try
                {
                    var startInfo = new ProcessStartInfo
                    {
                        FileName = Process.GetCurrentProcess().MainModule.FileName,
                        UseShellExecute = true,
                        Verb = "runas"
                    };
                    Process.Start(startInfo);
                    Environment.Exit(0); // Ferme l'ancien processus
                }
                catch
                {
                    Console.WriteLine("Élévation annulée.");
                }
            }
            else if (action == Environment.UserName && IsAdministrator())
            {
                Console.WriteLine("Retour en mode utilisateur...");

                try
                {
                    var startInfo = new ProcessStartInfo
                    {
                        FileName = Process.GetCurrentProcess().MainModule.FileName,
                        UseShellExecute = true
                        // Pas de Verb = "runas"
                    };
                    Process.Start(startInfo);
                    Environment.Exit(0);
                }
                catch
                {
                    Console.WriteLine("Échec du retour en mode utilisateur.");
                }
            }
            else if (IsAdministrator())
            {
                Console.WriteLine("Vous êtes déjà en mode superuser.");
            }
            else
            {
                Console.WriteLine("Commande sudo invalide ou permissions insuffisantes.");
            }
        }
    }
}
