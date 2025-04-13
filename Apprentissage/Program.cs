using System;
using System.ComponentModel.DataAnnotations;

namespace Apprentissage
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandManager commandManager = new CommandManager();

            // Répertorie les commandes présentes appellable
            commandManager.RegisterCommand("cd", new CdCommand());
            commandManager.RegisterCommand("pwd", new PwdCommand());
            commandManager.RegisterCommand("clear", new ClearCommand());
            commandManager.RegisterCommand("touch", new TouchCommand());
            commandManager.RegisterCommand("ls", new LsCommand());
            commandManager.RegisterCommand("rm", new RmCommand());
            commandManager.RegisterCommand("mkdir", new MkdirCommand());
            commandManager.RegisterCommand("sudo", new SudoCommand());

            /// Lopotit message au début du shell
            Console.WriteLine("Bienvenue dans ton mini-shell !");

            while (true)
            {
                /// Le mode (User car par encore sudo pour admin) le nom d'utilisateur et l'active directory
                Console.Write($"- (User@{Environment.UserName}) - [{Environment.CurrentDirectory}]\n- $ ");

                /// La saisie du con qui s'est dit que ce serait marrant d'avoir ça sur son pc
                string input = Console.ReadLine()?.Trim();

                /// Si c'est vide
                if (string.IsNullOrEmpty(input)) continue;

                /// La gestion des arguments
                string[] commandArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commandArgs[0].ToLower();
                string[] argsForCommand = commandArgs.Length > 1 ? commandArgs[1..] : new string[0];

                // L'exec depuis le gestionnaireè
                commandManager.ExecuteCommand(command, argsForCommand);
                if (command == "exit")
                {
                    return;
                }
            }
        }
    }
}
