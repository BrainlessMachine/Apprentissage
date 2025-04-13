using System;

namespace Apprentissage
{
    public class PwdCommand : ICommand
    {
        public void Execute(string[] args)
        {
            Console.WriteLine($"{Environment.CurrentDirectory}");
        }
    }
}
