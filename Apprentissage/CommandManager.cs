using System;
using System.Collections.Generic;

namespace Apprentissage
{
    public class CommandManager
    {
        private Dictionary<string, ICommand> commands;

        public CommandManager()
        {
            commands = new Dictionary<string, ICommand>();
        }

        /// Enregistrer les commandes
        public void RegisterCommand(string commandName, ICommand command)
        {
            commands[commandName] = command;
        }

        /// Exécuter une commande
        public void ExecuteCommand(string commandName, string[] args)
        {
            if (commands.ContainsKey(commandName))
            {
                commands[commandName].Execute(args);
            }
            else if (commandName == "exit")
            {
                Console.Write($"Bye !");
            }
            else
            {
                Console.WriteLine("Commande inconnue.");
            }
        }
    }
}
