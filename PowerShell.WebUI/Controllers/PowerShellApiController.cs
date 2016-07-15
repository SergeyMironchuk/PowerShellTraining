using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Web.Mvc;
using PowerShellFacades;

namespace PowerShell.WebUI.Controllers
{
    public class PowerShellApiController : Controller
    {
        // GET: PowerShell
        public JsonResult Run(string command)
        {
            var resultList = new List<string>();
            var powerShell = new PowerShellFacade();
            var commandArray = command.Split(' ');
            var argumets = new List<KeyValuePair<string, object>>();
            for (int i = 1; i < commandArray.Length; i = i+2)
            {
                argumets.Add(i < commandArray.Length - 1
                    ? new KeyValuePair<string, object>(commandArray[i], commandArray[i + 1])
                    : new KeyValuePair<string, object>(commandArray[i], null));
            }
            powerShell.RunCommandWithParameters(commandArray[0], argumets, objects =>
            {
                int i = 0;
                foreach (PSObject psObject in objects)
                {
                    foreach (var member in psObject.Properties)
                    {
                        if (member.IsInstance)
                        resultList.Add($"{++i}. {member.Name}={member.Value}");
                    }
                    resultList.Add($"{++i}. -------");
                }
            });
            return Json(resultList);
        }
    }
}