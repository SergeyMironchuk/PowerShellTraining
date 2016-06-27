using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Collections.ObjectModel;

namespace PowerShellFacades
{
    public class PowerShellFacade
    {
        public void RunCommandWithParameters(string commandName, IEnumerable<KeyValuePair<string, object>> parameters, Action<Collection<PSObject>> processComandResult)
        {
            using (PowerShell powershell = PowerShell.Create())
            {
                powershell.AddCommand(commandName);
                foreach (var parameter in parameters)
                {
                    powershell.AddParameter(parameter.Key, parameter.Value);
                }
                Collection<PSObject> results = powershell.Invoke();

                if (processComandResult != null) processComandResult(results);
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

                if (processComandResult != null) processComandResult(results);
            }
        }
    }
}