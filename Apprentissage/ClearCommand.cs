using System;

namespace Apprentissage
{
    public class ClearCommand : ICommand
    {
        public void Execute(string[] args)
        {
            Console.Clear();
            return;
        }
    }
}
