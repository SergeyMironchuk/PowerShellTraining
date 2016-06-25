using System;
using System.Collections.Generic;
using PowerShellFacades;

namespace TrainingProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var powerShell = new PowerShellFacade();
            powerShell.RunCommand("dir", new KeyValuePair<string, object>[0], objects =>
            {
                foreach (var psObject in objects)
                {
                    Console.WriteLine(psObject.ToString());
                }
            });
        }
    }
}
