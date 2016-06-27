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
            var parameters = new[]{"c:\\_Projects"};
            powerShell.RunCommandWithArguments("dir", parameters, objects =>
            {
                foreach (var psObject in objects)
                {
                    Console.WriteLine(psObject.ToString());
                }
            });
        }
    }
}
