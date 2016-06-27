using System;
using System.Collections.Generic;
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
            var commandData = command.Split(' ');
            List<string> argumets = new List<string>();
            if (commandData.Length > 1) argumets.Add(commandData[1]);
            powerShell.RunCommandWithArguments(commandData[0], argumets, objects =>
            {
                foreach (var psObject in objects)
                {
                    resultList.Add(psObject.ToString());
                }
            });
            return Json(resultList);
        }
    }
}