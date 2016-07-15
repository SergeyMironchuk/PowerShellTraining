using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Management.Automation.Runspaces;

namespace PowerShellFacades
{
    public class PowerShellFacade
    {
        public void RunCommandWithParameters(string commandName, IEnumerable<KeyValuePair<string, object>> parameters, Action<Collection<PSObject>> processComandResult)
        {
            using (PowerShell powershell = PowerShell.Create())
            {
                Command command = new Command(commandName);
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter.Key, parameter.Value);
                }
                powershell.Commands.AddCommand(command);
                Collection<PSObject> results = powershell.Invoke();

                processComandResult?.Invoke(results);
            }
        }

        public void RunCommandWithArguments(string commandName, IEnumerable<string> arguments, Action<Collection<PSObject>> processComandResult)
        {
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddCommand(commandName);
                foreach (var parameter in arguments)
                {
                    powershell.AddArgument(parameter);
                }
                Collection<PSObject> results = powershell.Invoke();

                processComandResult?.Invoke(results);
            }
        }
    }
}